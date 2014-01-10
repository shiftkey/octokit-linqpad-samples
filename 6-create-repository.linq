<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>Octokit</Namespace>
</Query>

// create a sample repository and modify the README
// these credentials won't work, you'll need to provide your own
var owner = "username";
var password = "password";
var repo = "my-awesome-repo-" + Environment.TickCount;
var author = "just some guy";
var email = "person@cooldomain.com";

var client = new GitHubClient(new ProductHeaderValue("Bay.NET"));
client.Credentials = new Credentials(owner, password);

// 1 - create a repository through the API
var newRepo = new NewRepository() { 
  Name = repo, 
  AutoInit = true // very helpful!
};
var repository = await client.Repository.Create(newRepo);
Console.WriteLine("Browse the repository at: " + repository.HtmlUrl);

// 2 - create a blob containing the contents of our README
var newBlob = new NewBlob() { 
   Content = "#MY AWESOME REPO\rthis is some code\rI made it on: " + DateTime.Now.ToString(), 
   Encoding = EncodingType.Utf8 
};

var createdBlob = await client.GitDatabase.Blob.Create(owner, repo, newBlob);
createdBlob.Dump();

// 3 - create a tree which represents just the README file
var newTree = new NewTree();
newTree.Tree.Add(new NewTreeItem() { 
  Path = "README.md", 
  Mode = Octokit.FileMode.File,
  Sha = createdBlob.Sha,
  Type = TreeType.Blob
});

var createdTree = await client.GitDatabase.Tree.Create(owner, repo, newTree);
createdTree.Dump();

// 4 - this commit should build on the current master branch
var master = await client.GitDatabase.Reference.Get(owner, repo, "heads/master");

var newCommit = new NewCommit(
  "Hello World!", 
  createdTree.Sha, 
  new[] { master.Object.Sha });
newCommit.Author = new Signature() { 
  Name =  author,
  Email = email,
  Date = DateTime.UtcNow
};
var createdCommit = await client.GitDatabase.Commit.Create(owner, repo, newCommit);
createdCommit.Dump();

// 5 - create a reference for the master branch
var updateReference = new ReferenceUpdate(createdCommit.Sha);
var updatedReference = await client.GitDatabase.Reference.Update(owner, repo, "heads/master", updateReference);
updatedReference.Dump();
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

var client = new GitHubClient(new ProductHeaderValue("Bay.NET"));
var releases = await client.Release.GetAll("octokit", "octokit.net");

// we have to build up this tag because release tags
// are just lightweight tags. you can read more about
// the differences between lightweight tags and annotated tags
// here: http://git-scm.com/book/en/Git-Basics-Tagging#Creating-Tags

// we can fetch the tag for this release
var reference = "tags/" + releases[0].TagName;
var tag = await client.GitDatabase.Reference.Get("octokit", "octokit.net", reference);
tag.Dump();

// and we can fetch the commit associated with this release
var commit = await client.GitDatabase.Commit.Get("octokit", "octokit.net", tag.Object.Sha);
commit.Dump();
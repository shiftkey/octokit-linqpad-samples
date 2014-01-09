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
var repository = await client.Repository.Get("octokit", "octokit.net");
Console.WriteLine("Octokit.net can be found at {0}\n", repository.HtmlUrl);

Console.WriteLine("It currently has {0} watchers and {0} forks\n", 
    repository.WatchersCount,
    repository.ForksCount);

Console.WriteLine("It has {0} open issues\n", repository.OpenIssuesCount);

Console.WriteLine("And GitHub thinks it is a {0} project", repository.Language);

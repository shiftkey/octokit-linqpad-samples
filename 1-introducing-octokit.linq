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
Console.WriteLine("Octokit.net can be found at {0}", repository.HtmlUrl);
Console.WriteLine();
Console.WriteLine("It is allegedly a {0} project", repository.Language);
Console.WriteLine("and currently has {0} forks", repository.ForksCount);
Console.WriteLine("and also {0} watchers", repository.WatchersCount);
Console.WriteLine("It currently has {0} outstanding issues", repository.OpenIssuesCount);

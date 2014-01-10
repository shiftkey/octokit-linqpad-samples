<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>Octokit.Reactive</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

var client = new ObservableGitHubClient(new ProductHeaderValue("Bay.NET"));

client.Repository.GetAllForUser("shiftkey").Select(r => r.Name).Dump();
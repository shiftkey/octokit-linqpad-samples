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

var repositories = await client.Repository.GetAllForUser("haacked");
repositories.Select(r => new { r.Name }).Dump();

// basic authentication
//client.Credentials = new Credentials("username", "password");

// or if you don't want to give an app your creds
// you can use a token from an OAuth app
//client.Credentials = new Credentials("some-token-here");

// and then fetch the repositories for the current user
//var repositories = await client.Repository.GetAllForCurrent()
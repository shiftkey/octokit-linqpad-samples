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
releases.Select(r => new { r.Name, r.Body }).Dump();

// release tags are lightweight tags
// more information: releases[0].TagName
var reference = "tags/" + releases[0].TagName;
var tag = await client.GitDatabase.Reference.Get("octokit", "octokit.net", reference);
// this is the corresponding tag in the Git database
tag.Dump();
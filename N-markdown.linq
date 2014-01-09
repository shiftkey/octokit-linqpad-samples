<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Media.Imaging</Namespace>
</Query>

var client = new GitHubClient(new ProductHeaderValue("Bay.NET"));
var text = await client.Miscellaneous.RenderRawMarkdown(
    "## HELLO BAY.NET\n\n"
  + ":dancer:\n\n"
  + " - this is an item\n"
  + " - and another item");

// see the HTML
text.Dump();
// view it in the local browser
var localUrl = Path.GetTempFileName() + ".html";
File.WriteAllText(localUrl, text);
Process.Start(localUrl);
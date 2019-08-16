<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.NetworkInformation.dll</Reference>
  <Namespace>System.Net.NetworkInformation</Namespace>
</Query>

/*
	forces PLINQ to run the specified number of tasks simultaneously. 
	This is necessary when calling blocking functions such as Ping.
	Send because PLINQ otherwise assumes that the query is CPU-intensive 
	and allocates tasks accordingly. On a two-core machine, for instance,
	PLINQ may default to running only two tasks at once, which is clearly 
	undesirable in this situation.
*/
var websites = new[]
{
    "www.linqpad.net",
    "stackoverflow.com",
    "google.com",
    "bing.com",
    "www.msn.com",
	"facebook.com"
};

websites
	.AsParallel()
	.WithDegreeOfParallelism(websites.Length) 
	.Select(site => new {Site = site, Ping = new Ping().Send(site)})
	.ForAll(x => x.Ping.Dump(x.Site));
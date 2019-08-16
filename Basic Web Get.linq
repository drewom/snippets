<Query Kind="Statements" />

var websites = new[]
{
    "http://google.com",
	"http://bing.com",
	"http://facebook.com"
};

websites
	.AsParallel()
	.WithDegreeOfParallelism(websites.Length) 
	.Select(site => 
	{ 
		string x = "";
		using (var wc = new System.Net.WebClient())
		{
			x =  wc.DownloadString(site);
		}
		return x;
	})
	.ForAll(x => x.Dump());
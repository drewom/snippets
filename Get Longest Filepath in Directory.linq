<Query Kind="Expression" />

Directory
	.GetFiles(@"\\snowblade\Shared Documents\Documents - Ion Fund\Fund Accounting\"
		+ @"Clearing Files - Morgan Stanley\", 
		"*.csv", 
		SearchOption.AllDirectories)
	.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur)
	//.Length
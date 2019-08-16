<Query Kind="Statements" />

var positives = new decimal[]{ 
0M, 1M, 2M, 4M, 1M, 10M, 100M, .1M, .01M, .001M,
+0.000000000000000000000000001m, decimal.MaxValue, decimal.MaxValue/10M, 
12315651613514666.15321165m };
"+ve".Dump();
foreach (decimal foo in positives)
{
	string.Join("-", 
	decimal.GetBits(foo)
	       .Select(x => Convert.ToString(x, 2)
		                       .PadLeft(32, '0'))
	).Dump("" + foo);
}
"-ve".Dump();
foreach (decimal foo in positives.Select(x => -x))
{
	string.Join("-", 
	decimal.GetBits(foo)
	       .Select(x => Convert.ToString(x, 2)
		                       .PadLeft(32, '0'))
	).Dump("" + foo);
}
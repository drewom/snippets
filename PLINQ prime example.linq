<Query Kind="Statements" />

Enumerable
	.Range(3, int.MaxValue-3) // does not return 2
    .AsParallel()
    .Where(number => Enumerable.Range(2, (int) Math.Sqrt(number))
    					       .All(devisor => number%devisor > 0))
	.Select(prime => prime.Dump())
	.ToList();
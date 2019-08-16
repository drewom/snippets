<Query Kind="Program" />

/// <summary>
/// Main function.
/// </summary>
void Main()
{
	foreach (var equation in ToStringEqu(QuestionSix(2000000, 1000000)))
	{
		// dump all results to the results window 
		equation.Dump();
	}
}

/// <summary>
/// Brute force equation values for the 1988 Maths Olympiad, Question 6.
/// (a² + b²) / (ab + 1) = c where c is of the real +/ve integers set, then √c is also of the real integers set.
/// we ignore values where a or b == 0 as if one is zero then you have infinite solutions for every other value 
/// of the other.
/// <summary>
/// <param name="total">end of search, once there are no results that sums are less then total, funtion returns.</param>
/// <param name="startAt">start of search, function return the first </param>
/// <return>set of tuples that</return>
/// <remarks>
///	youtu.be/Y30VF3cSIYQ
///	We perform a parameter-sum breath-search (diagonal) as oppose to searching all of b for a given a. 
///	[[0,0],[0,1],[1,0],[0,2],[1,1],[2,0],[0,3],..,[n-1,1],[n,0]]
/// </remarks>
IEnumerable<Tuple<long, long>> QuestionSix(long total, long startAt = 2)
{	
	if (total < 1   || total   == long.MaxValue)                    
		throw new ArgumentException(nameof(total),   "total invalid value " + total);
	if (startAt < 1 || startAt == long.MaxValue || startAt > total) 
		throw new ArgumentException(nameof(startAt), "startAt invalid value " + startAt);
	
	// for each set of possible values of [a,b] where a + b == total
	for (long sum = startAt; sum < total+1; ++sum)
	{
		
		// start at [1, n-1], every case of [0,n] and [n,0] are valid and they muddy the results.
		long a = 1;
		long b = sum-1;
		
		do
		{
			// calculate the top and bottom of this pair
			long numerator   = a*a + b*b;
			long denominator = a*b + 1;
			// is the value not a fraction
			if (numerator % denominator == 0)
			{
				// found one! 
				yield return new Tuple<long, long>(a, b);
			}
			
			// inc. to the nex set
			a++;
			b--;
		}
		while(b >= a); // a and b are interchangeible, so we can stop once they pass.
	}
}

/// <summary>
///  Show resultant [a,b] pairs as their neatly formatted string representation.
/// </summary>
/// <param name="startAt">Enumerable of pairs of values, expected to be correct values for 
/// (a² + b²) / (ab + 1) = c where c is of set integer.</param>
/// <returns>Enumerable of the results with there equations in human readable form</returns>
IEnumerable<string> ToStringEqu(IEnumerable<Tuple<long, long>> Exq)
{	
	foreach (var pair in Exq)
	{	
		long a = pair.Item1;
		long b = pair.Item2;
		
		long result = (a*a + b*b) / (a*b + 1);
		
		yield return $"{a,6}² + {b + "²",-7} / {a,6} x {b,-6} + 1 = {result,5} = {Math.Sqrt(result) + "²",-2}";
	}
}
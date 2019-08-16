<Query Kind="Program" />

void Main()
{
	long[] ns  = Enumerable.Range(1, 10).Select(n => (long)n).ToArray();
	long[] fns = ns.Select(n => Factorial(n)).ToArray();
	long[] fns2 = fns.Select(n => ReverseFactorial(n)).ToArray();
	
	for (int iter = 0; iter != ns.Length; ++iter)
	{
		if (fns[iter] != fns2[iter])
		{
			("Fail! f(" + ns[iter] + ") != " + fns2[iter] + "?").Dump();
		}
	}
}

public static long Factorial(long number)
{
    int accumulator = 1;
    for (int factor = 1; factor <= number; factor++)
    {
        accumulator *= factor;
    }
    return accumulator;
}
public static long ReverseFactorial(long input)
{
	int count = 1;
	while (count < input)
	{
		count += 1;
		if (count == input)
	}
	return -1;
}

// 6! = 6*5*4*3*2*1 = 720
// 
// Define other methods and classes here

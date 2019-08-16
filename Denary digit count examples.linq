<Query Kind="Program" />

// to string version
int DigitCountToString (int n) 
{
    if (n < 0) n = -n;
    return n.ToString().Length;
}
// mathematical version with log10
int DigitCountLog10 (int n) 
{
    if (n == int.MinValue) return 10;
    if (n == 0) return 1;
    return (int)Math.Log10(Math.Abs(n))+1;
}
// lookup with branches
int DigitCountBranchLookup (int n) 
{
    if (n == int.MinValue) return 10;
    if (n < 0) n = -n;
    if (n < 10) return 1;
    if (n < 100) return 2;
    if (n < 1000) return 3;
    if (n < 10000) return 4;
    if (n < 100000) return 5;
    if (n < 1000000) return 6;
    if (n < 10000000) return 7;
    if (n < 100000000) return 8;
    if (n < 1000000000) return 9;
    return 10;
}
// reverse lookup with branches
int DigitCountBranchLookupReverse (int n) 
{
    if (n == int.MinValue) return 10;
    if (n < 0) n = -n;
    if (n > 999999999) return 10;
    if (n > 99999999) return 9;
    if (n > 9999999) return 8;
    if (n > 999999) return 7;
    if (n > 99999) return 6;
    if (n > 9999) return 5;
    if (n > 999) return 4;
    if (n > 99) return 3;
    if (n > 9) return 2;
    return 1;
}

static readonly int[]  MultiplyDeBruijnBitPosition= new int [] 
{
  0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30,
  8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31
};
static readonly uint[] PowersOf10 = 
{
	1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000
};
int IntegerLogBase2 (uint v)
{	
	v |= v >> 1; // first round down to one less than a power of 2 
	v |= v >> 2;
	v |= v >> 4;
	v |= v >> 8;
	v |= v >> 16;
	
	return MultiplyDeBruijnBitPosition[(uint)(v * 0x07C4ACDDU) >> 27];
}

int IntegerLogBase10 (uint v)
{	
	int t;          // temporary
	t = (IntegerLogBase2(v) + 1) * 1233 >> 12; // (use a lg2 method from above)
	return (int) (t - (v - PowersOf10[t])); //(v < PowersOf10[t]);
}

void TimeFunction (int start, int end, System.Func<int, int> fn, string name)
{
	var rng = new Random();
	var sw = Stopwatch.StartNew();
	for (int i = start; i < end; i++) fn(rng.Next());
	sw.Stop();
	sw.Elapsed.Dump(name);
}

void Main()
{
	for (int i = short.MinValue; i < short.MaxValue; i++) 
	{
		Debug.Assert(DigitCountLog10(i) == DigitCountBranchLookupReverse(i),
		    $"f1({DigitCountLog10(i)}, {DigitCountBranchLookupReverse(i)}) - {i}");
		Debug.Assert(DigitCountToString(i) == DigitCountBranchLookupReverse(i),
		    $"f2({DigitCountToString(i)}, {DigitCountBranchLookupReverse(i)}) - {i}");
		Debug.Assert(DigitCountBranchLookup(i) == DigitCountBranchLookupReverse(i),
		    $"f3({DigitCountBranchLookup(i)}, {DigitCountBranchLookupReverse(i)}) - {i}");
	}
	
	const int min = short.MinValue>>8, max = short.MaxValue<<8;
	
	TimeFunction(min, max, DigitCountToString,            "ToString");
	TimeFunction(min, max, DigitCountLog10,               "Log10");
	TimeFunction(min, max, DigitCountBranchLookup,        "Branch-Lookup");
	TimeFunction(min, max, DigitCountBranchLookupReverse, "Branch-Lookup-Reverse");
}

// Define other methods and classes here
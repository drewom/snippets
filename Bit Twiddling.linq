<Query Kind="Program" />

void Main()
{
//	sex(-1).Dump();
//	sex(-153531).Dump();
//	sex(1).Dump();
//	sex(153531).Dump();
//	
//	abs(123156).Dump();
//	abs(-123156).Dump();
//	
//	min(-1,-2).Dump();
//	min(-1,2).Dump();
//	min(1,2).Dump();
//	min(-1,-1).Dump();
//	min(-2,-2).Dump();
//	
//	max(-1,-2).Dump();
//	max(-1,2).Dump();
//	max(1,2).Dump();
//	max(-1,-1).Dump();
//	max(-2,-2).Dump();

	var list = Enumerable
		.Range(short.MinValue, short.MaxValue-short.MinValue)
		.ToList();
	
	list = list.Concat(list).ToList();
	list = list.Concat(list).ToList();
	list = list.Concat(list).ToList();
	list = list.Concat(list).ToList();
	list = list.Concat(list).ToList();
	list = list.Concat(list).ToList();
	
	var pairs = list.AsPairs().ToList();
	int a = 0;
	list.Shuffle();
	
	var sw = Stopwatch.StartNew();
	foreach(var num in list)
	{
		Math.Abs(num);
	}
	sw.Stop();
	sw.Elapsed.Ticks.ToString("N0").Dump(nameof(Math.Abs));
	
	sw = Stopwatch.StartNew();
	foreach(var pair in pairs)
	{
		Math.Min(pair.Item1, pair.Item2);
	}
	sw.Stop();
	
	sw.Elapsed.Ticks.ToString("N0").Dump(nameof(Math.Min));
	
	sw = Stopwatch.StartNew();
	foreach(var pair in pairs)
	{
		Math.Max(pair.Item1, pair.Item2);
	}
	sw.Stop();
	sw.Elapsed.Ticks.ToString("N0").Dump(nameof(Math.Max));
	
	sw = Stopwatch.StartNew();
	foreach(var x in list)
	{
//		if (x == int.MinValue)
//		{
//			throw new Exception("");
//		}
	 	//a += (x ^ sex(x)) - sex(x);
//	
		if (x >= 0)
              a += x; 
          else
              a += -(x);
	}
	sw.Stop();
	sw.Elapsed.Ticks.ToString("N0").Dump(nameof(abs));
	
	sw = Stopwatch.StartNew();
	foreach(var pair in pairs)
	{
		min(pair.Item1, pair.Item2);
	}
	sw.Stop();
	sw.Elapsed.Ticks.ToString("N0").Dump(nameof(min));
	
	sw = Stopwatch.StartNew();
	foreach(var pair in pairs)
	{
		max(pair.Item1, pair.Item2);
	}
	sw.Stop();
	sw.Elapsed.Ticks.ToString("N0").Dump(nameof(max));
	Console.WriteLine(a);
}

int sex(int x) 
{
	return x >> (8*sizeof(int)-1);
}

int Abs(int value) { 
          if (value >= 0)
              return value; 
          else
              return -(value);
      }

int abs(int x)
{
	if (x == int.MinValue)
	{
		throw new Exception("");
	}
	return (x ^ sex(x)) - sex(x);
}
int min(int a, int b)
{
	return b + ((a-b) & sex(a-b));
} 
int max(int a, int b)
{
	return a + ((b-a) & ~sex(b-a));
}
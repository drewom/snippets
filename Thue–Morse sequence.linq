<Query Kind="Program" />

void Main()
{
	const int level = 7;
	const ulong end = 1UL << (level);
	ThueMorseSequence1(level).Dump();
	ThueMorseSequence2(level).Dump();
    var builder = new StringBuilder();
	foreach(bool num in ThueMorseSequenceCoroutine(level))
	{
		builder.Append(num 
						? "1" 
						: "0"
					  );
	}
	builder.ToString().Dump();
	
    var builder2 = new StringBuilder();
	
	for(ulong num = 0; num < end; num++)
	{
		builder2.Append(AreBitsOdd(num)
						? "1" 
						: "0"
					  );
	}
	builder2.ToString().Dump();
}

void TimeFunction (int start, int end, System.Func<int, int> fn, string name)
{
	var sw = Stopwatch.StartNew();
	for (int i = start; i < end; i++) fn(i);
	sw.Stop();
	sw.Elapsed.Dump(name);
}

public static string ThueMorseSequence1(int steps)
{
	int finalLength = (int)Math.Pow(2, steps);
	string current = "0";
	for (int i = 0; i < steps; ++i)
	{
		current = current.Replace("0", "02");
		current = current.Replace("1", "10");
		current = current.Replace("2", "1");
	}
	return current;
}

public static string ThueMorseSequence2(int steps) 
{
    var sb1 = new StringBuilder("0");
    var sb2 = new StringBuilder("1");
    for (int i = 0; i < steps; i++) 
	{
        String tmp = sb1.ToString();
        sb1.Append(sb2);
        sb2.Append(tmp);
    }
    return sb1.ToString();
}

public static IEnumerable<bool> ThueMorseSequenceCoroutine(int steps) 
{
    var left  = new List<bool>{false};
    var right = new List<bool>{true};
	int c = 0;
    for (int i = 0; i < steps; i++) 
	{
        var tmp = new List<bool>(left);
        left.AddRange(right);
        right.AddRange(tmp);
		for (; c < left.Count; ++c)
		{
			yield return left[c];
		}
    }
}
bool AreBitsOdd(ulong i)
{
	// using Hamming weight
    i = i - ((i >> 1) & 0x5555555555555555UL);
    i = (i & 0x3333333333333333UL) +
	   ((i >> 2) & 0x3333333333333333UL);
    return ((int)(unchecked(((i + (i >> 4)) & 0xF0F0F0F0F0F0F0FUL) * 0x101010101010101UL) >> 56) % 2) == 1;
}

<Query Kind="Statements" />

long[] results = new long[10000];
var sw = new Stopwatch();
int i = 0;
sw.Start();
for (; i < 10000; ++i)
{
    results[i] = sw.Elapsed.Ticks;
}
sw.Stop();

results.Dump();
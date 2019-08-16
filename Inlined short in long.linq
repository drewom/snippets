<Query Kind="Statements" />

long iter = (1L << (sizeof(long) * 6));
long iter2 = 0;
for(int i = 0; i < ushort.MaxValue; i++)
{
	Interlocked.Add(ref iter2, iter); // inc both 3/4 long and short
}
iter2.ToString("X16").Dump("HEX");
iter2.Dump("DEC signed");
((ulong)iter2).Dump("DEC unsigned");

Interlocked.Add(ref iter2, iter);

iter2.ToString("X16").Dump("HEX");
iter2.Dump("DEC");

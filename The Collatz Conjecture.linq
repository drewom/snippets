<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

ulong iStart = 1UL << 24;
("f([" + iStart + ",.., 1])").Dump();
ulong maxIndex = 0;
int max = 0;
for (ulong i = iStart; i > 0; --i)
{
	ulong j = i;
	int count = 0;
	var jmod2 = j%2;
	while ((j = (jmod2) * (j*3+1) + (1 - jmod2) * (j /2)) != 1)
	{
		jmod2 = j%2;
		++count;
	}
	if (max < count)
	{
		maxIndex = i;
		max = count;
	}
}
("[" + maxIndex + "] = steps: " + max).Dump();
{
	var route = new List<ulong>(max);
	ulong j = maxIndex;
	route.Add(j);
	while ((j = (j % 2) * (j*3+1) + (1 - j % 2) * (j /2)) != 1)
	{
		route.Add(j);
	}
	route.Add(j);
	string.Join("\n", route).Dump();
}
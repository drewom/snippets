<Query Kind="Statements" />

var list = new List<int>(1000000);
bool allowDups = true;
var rng = new Random();
for(int iter = 0; iter != 1000; ++iter)
{
	var index = rng.Next(0, 1000);
	var ind = list.BinarySearch(index);
	if (ind < 0)        list.Insert(~ind, index); // new
	else if (allowDups) list.Insert(ind,  index); // duplicate		
}
list.Count.Dump();
list.Dump();
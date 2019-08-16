<Query Kind="Program" />

void Main()
{
	var rng = new Random();
	var insertList = RandomSequence(rng).Distinct().Take(100).Select(n => ((double)n)*0.01d).ToList();
	var lists = new[]{
		new List<double>{},
		new List<double>{0d},
		RandomSequence(rng).Distinct().Take(100).Select(n => ((double)n)*0.01d).OrderBy(d => d).ToList(),
		RandomSequence(rng).Distinct().Take(100).Select(n => ((double)n)*0.01d).OrderBy(d => d).ToList()
	};
	List<List<double>> results = new List<List<double>>();

	foreach (var list in lists)
	{
		list.Dump ();
	
		foreach (var insert in insertList)
		{
			int index = BinarySearchInsertAt(list, key => key, insert, false);
			if (index != -1)
			{
				var result = new List<double>(list);
				result.Insert(index, insert);
				result.Dump ("insert " + insert + " @: " + index);
				results.Add(result);
			}
			else
			{
				index.Dump ("Key already found");
			}
		}
	}
	foreach (var result in results)
	{
		double current = result.First();
		foreach (var value in result.Skip(1))
		{
			if (current > value)
			{
				result.Dump ("Out of Order!");
			}
			current = value;
		}
	}
}
IEnumerable<int> RandomSequence(Random random)
{
    while(true)
    {
      yield return random.Next(-200, 200);
    }
}

   public static int BinarySearchInsertAt<T, TKey>(IList<T> list, Func<T, TKey> orderedByKeySelector, TKey key, bool descending)
       where TKey : IComparable
   {
       int min = 0;
       int max = list.Count;
       if (list.Count > 0)
       {
           while (min < max)
           {
               int middle = min + (max - min) / 2;
               TKey comparisonValue = orderedByKeySelector(list[middle]);

               int comparison = descending
                   ? -comparisonValue.CompareTo(key)
                   : comparisonValue.CompareTo(key);

               if (comparison < 0)
               {
                   min = middle + 1;
               }
               else if (comparison > 0)
               {
                   max = middle;
               }
               else // comparison == 0
               {
                   // we shouldn't find the actual element
                   return -1;
               }
           }
           // end of list, is the end right?
           if (min == max
               && min < list.Count
               && orderedByKeySelector(list[min]).CompareTo(key) == 0)
           {
               // we shouldn't find the actual element
               return -1;
           }
       }
       // return -1 to indicate it was not found
       return min;
   }
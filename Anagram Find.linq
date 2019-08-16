<Query Kind="Statements" />

System.Net.WebRequest request = System.Net.WebRequest.Create("http://www-01.sil.org/linguistics/wordlists/english/wordlist/wordsEn.txt");
string[] words;

using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), true))
{
    words = Regex.Split(reader.ReadToEnd(), @"\r?\n");
}
var groups =
    words.GroupBy(word => string.Concat(word.OrderBy(character => character)))
         .GroupBy(letterCount => letterCount.Count())
         .OrderByDescending(sizeGrouping => sizeGrouping.Key);
		 
foreach (var sizeGrouping in groups.Where(group => group.Count() != 0))
{
	string.Join(" ", sizeGrouping.First()).Dump();
}
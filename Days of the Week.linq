<Query Kind="Statements" />

List<DateTime> allDates = new List<DateTime>();

var startingDate = new DateTime(2016,2,11);
var endingDate   = new DateTime(2016,3,3);
for (DateTime i = startingDate; i <= endingDate; i = i.AddDays(1))
{
	if	(i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
   	{
		allDates.Add(i);
	}   
}
allDates.Select(date => "" + date.ToString("yyyy-MM-dd ddd")).Dump();
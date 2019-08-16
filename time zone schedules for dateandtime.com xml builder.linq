<Query Kind="Program" />

enum MilitaryTimeZoneNames
{
    Alpha    = +1,
    Bravo    = +2,
    Charlie  = +3,
    Delta    = +4,
    Echo     = +5,
    Foxtrot  = +6,
    Golf     = +7,
    Hotel    = +8,
    India    = +9,
    Kilo     = +10,
    Lima     = +11,
    Mike     = +12,
    November = -1,
    Oscar    = -2,
    Papa     = -3,
    Quebec   = -4,
    Romeo    = -5,
    Sierra   = -6,
    Tango    = -7,
    Uniform  = -8,
    Victor   = -9,
    Whiskey  = -10,
    Xray     = -11,
    Yankee   = -12,
    Zulu     = +0
};

private IEnumerable<string> AddDateTimeMinValueLine(IEnumerable<string> postfixes, int startOffset)
{
	yield return $"0001	Mon, 01 Jan, 00:00	??? → ???	+0 hour (DST END?)	UTC{startOffset.ToString("+#;-#")}h";
    foreach (var fix in postfixes)
		yield return fix;
}

void Main()
{
	int counter = 9;
	
	var startOffsets = new Dictionary<string, int>()
	{
		{"AEST/AEDT", +11},
		{"BRT/BRST",   -2},
		{"CLT/CLST",   -3},
		{"EET/EEST",   +2},
		{"WIB",   	   +7},
		{"UTC/IST",    +0},
		{"KST",   	   +9},
		{"MYT",   	   +8},
		{"NZST/NZDT", +13},
		{"PHT", 	   +8},
		{"WET/WEST",   +0},
		{"SGT",   	   +8},
		{"SAST",   	   +2},
		{"CST",   	   +8},
		{"ICT",   	   +7},
	};
	
	var vals = new Dictionary<Tuple<string, string>, string[]>()
    {
        {
            new Tuple<string, string>("AEST/AEDT", "Australian Eastern Standard Time/Australian Eastern Daylight Time"),
            new[]
            {
                "2016	Sun, 3 Apr, 03:00	AEDT → AEST	-1 hour (DST end)	UTC+10h",
				"2016 	Sun, 2 Oct, 02:00	AEST → AEDT	+1 hour (DST start)	UTC+11h",
				"2017	Sun, 2 Apr, 03:00	AEDT → AEST	-1 hour (DST end)	UTC+10h",
				"2017 	Sun, 1 Oct, 02:00	AEST → AEDT	+1 hour (DST start)	UTC+11h",
				"2018	Sun, 1 Apr, 03:00	AEDT → AEST	-1 hour (DST end)	UTC+10h",
				"2018 	Sun, 7 Oct, 02:00	AEST → AEDT	+1 hour (DST start)	UTC+11h",
				"2019	Sun, 7 Apr, 03:00	AEDT → AEST	-1 hour (DST end)	UTC+10h",
				"2019 	Sun, 6 Oct, 02:00	AEST → AEDT	+1 hour (DST start)	UTC+11h",
				"2020	Sun, 5 Apr, 03:00	AEDT → AEST	-1 hour (DST end)	UTC+10h",
				"2020 	Sun, 4 Oct, 02:00	AEST → AEDT	+1 hour (DST start)	UTC+11h"
            }
        },
        {
            new Tuple<string, string>("BRT/BRST", "Brazilian Time/Brazilian Summer Time"),
            new[]
            {
                "2016	Sun, 21 Feb, 00:00	BRST → BRT	-1 hour (DST end)	UTC-3h",
                "2016	Sun, 16 Oct, 00:00	BRT → BRST	+1 hour (DST start)	UTC-2h",
                "2017	Sun, 19 Feb, 00:00	BRST → BRT	-1 hour (DST end)	UTC-3h",
                "2017	Sun, 15 Oct, 00:00	BRT → BRST	+1 hour (DST start)	UTC-2h",
                "2018	Sun, 18 Feb, 00:00	BRST → BRT	-1 hour (DST end)	UTC-3h",
                "2018	Sun, 21 Oct, 00:00	BRT → BRST	+1 hour (DST start)	UTC-2h",
                "2019	Sun, 17 Feb, 00:00	BRST → BRT	-1 hour (DST end)	UTC-3h",
                "2019	Sun, 20 Oct, 00:00	BRT → BRST	+1 hour (DST start)	UTC-2h",
                "2020	Sun, 16 Feb, 00:00	BRST → BRT	-1 hour (DST end)	UTC-3h",
                "2020	Sun, 18 Oct, 00:00	BRT → BRST	+1 hour (DST start)	UTC-2h"
            }
        },
        {
            new Tuple<string, string>("CLT/CLST", "Chile Standard Time/Chile Summer Time"),
            new[]
            {
				"2016	Sun, 15 May, 00:00	CLST → CLT	-1 hour (DST end)	UTC-4h",
				"2016 	Sun, 14 Aug, 00:00	CLT → CLST	+1 hour (DST start)	UTC-3h",
				"2017	Sun, 14 May, 00:00	CLST → CLT	-1 hour (DST end)	UTC-4h",
				"2017 	Sun, 13 Aug, 00:00	CLT → CLST	+1 hour (DST start)	UTC-3h",
				"2018	Sun, 13 May, 00:00	CLST → CLT	-1 hour (DST end)	UTC-4h",
				"2018 	Sun, 12 Aug, 00:00	CLT → CLST	+1 hour (DST start)	UTC-3h",
				"2019	Sun, 12 May, 00:00	CLST → CLT	-1 hour (DST end)	UTC-4h",
				"2019 	Sun, 11 Aug, 00:00	CLT → CLST	+1 hour (DST start)	UTC-3h",
				"2020	Sun, 10 May, 00:00	CLST → CLT	-1 hour (DST end)	UTC-4h",
				"2020 	Sun, 9 Aug, 00:00	CLT → CLST	+1 hour (DST start)	UTC-3h"
            }
        },
        {
            new Tuple<string, string>("EET/EEST", "Eastern European Time/Eastern European Summer Time"),
            new[]
            {
					"2016	Sun, 27 Mar, 03:00	EET → EEST	+1 hour (DST start)	UTC+3h",
					"2016 	Sun, 30 Oct, 04:00	EEST → EET	-1 hour (DST end)	UTC+2h",
					"2017	Sun, 26 Mar, 03:00	EET → EEST	+1 hour (DST start)	UTC+3h",
					"2017 	Sun, 29 Oct, 04:00	EEST → EET	-1 hour (DST end)	UTC+2h",
					"2018	Sun, 25 Mar, 03:00	EET → EEST	+1 hour (DST start)	UTC+3h",
					"2018 	Sun, 28 Oct, 04:00	EEST → EET	-1 hour (DST end)	UTC+2h",
					"2019	Sun, 31 Mar, 03:00	EET → EEST	+1 hour (DST start)	UTC+3h",
					"2019 	Sun, 27 Oct, 04:00	EEST → EET	-1 hour (DST end)	UTC+2h",
					"2020	Sun, 29 Mar, 03:00	EET → EEST	+1 hour (DST start)	UTC+3h",
					"2020 	Sun, 25 Oct, 04:00	EEST → EET	-1 hour (DST end)	UTC+2h"
            }
        },
        {
            new Tuple<string, string>("WIB", "Western Indonesian Time"),
            new string[]{}
        },
        {
            new Tuple<string, string>("UTC/IST", "Coordinated Universal Time/Irish Standard Time"),
            new string[]
			{
				"2016	Sun, 27 Mar, 01:00	GMT → IST	+1 hour (DST start)	UTC+1h",
				"2016 	Sun, 30 Oct, 02:00	IST → GMT	-1 hour (DST end)	UTC",
				"2017	Sun, 26 Mar, 01:00	GMT → IST	+1 hour (DST start)	UTC+1h",
				"2017 	Sun, 29 Oct, 02:00	IST → GMT	-1 hour (DST end)	UTC",
				"2018	Sun, 25 Mar, 01:00	GMT → IST	+1 hour (DST start)	UTC+1h",
				"2018 	Sun, 28 Oct, 02:00	IST → GMT	-1 hour (DST end)	UTC",
				"2019	Sun, 31 Mar, 01:00	GMT → IST	+1 hour (DST start)	UTC+1h",
				"2019 	Sun, 27 Oct, 02:00	IST → GMT	-1 hour (DST end)	UTC",
				"2020	Sun, 29 Mar, 01:00	GMT → IST	+1 hour (DST start)	UTC+1h",
				"2020 	Sun, 25 Oct, 02:00	IST → GMT	-1 hour (DST end)	UTC"
			}
        },
        {
            new Tuple<string, string>("KST", "Korea Standard Time"),
            new string[]{}
        },
        {
            new Tuple<string, string>("MYT", "Malaysia Time"),
            new string[]{}
        },
        {
            new Tuple<string, string>("NZST/NZDT", "New Zealand Standard Time/New Zealand Daylight Time"),
            new string[]
			{
				"2016	Sun, 3 Apr, 03:00	NZDT → NZST	-1 hour (DST end)	UTC+12h",
				"2016 	Sun, 25 Sep, 02:00	NZST → NZDT	+1 hour (DST start)	UTC+13h",
				"2017	Sun, 2 Apr, 03:00	NZDT → NZST	-1 hour (DST end)	UTC+12h",
				"2017 	Sun, 24 Sep, 02:00	NZST → NZDT	+1 hour (DST start)	UTC+13h",
				"2018	Sun, 1 Apr, 03:00	NZDT → NZST	-1 hour (DST end)	UTC+12h",
				"2018 	Sun, 30 Sep, 02:00	NZST → NZDT	+1 hour (DST start)	UTC+13h",
				"2019	Sun, 7 Apr, 03:00	NZDT → NZST	-1 hour (DST end)	UTC+12h",
				"2019 	Sun, 29 Sep, 02:00	NZST → NZDT	+1 hour (DST start)	UTC+13h",
				"2020	Sun, 5 Apr, 03:00	NZDT → NZST	-1 hour (DST end)	UTC+12h",
				"2020 	Sun, 27 Sep, 02:00	NZST → NZDT	+1 hour (DST start)	UTC+13h"
			}
        },
        {
            new Tuple<string, string>("PHT", "Philippine Time"),
            new string[]{}
        },
        {
            new Tuple<string, string>("WET/WEST", "Western European Time/Western European Summer Time"),
            new string[]
			{
				"2016	Sun, 27 Mar, 01:00	WET → WEST	+1 hour (DST start)	UTC+1h",
				"2016 	Sun, 30 Oct, 02:00	WEST → WET	-1 hour (DST end)	UTC",
				"2017	Sun, 26 Mar, 01:00	WET → WEST	+1 hour (DST start)	UTC+1h",
				"2017 	Sun, 29 Oct, 02:00	WEST → WET	-1 hour (DST end)	UTC",
				"2018	Sun, 25 Mar, 01:00	WET → WEST	+1 hour (DST start)	UTC+1h",
				"2018 	Sun, 28 Oct, 02:00	WEST → WET	-1 hour (DST end)	UTC",
				"2019	Sun, 31 Mar, 01:00	WET → WEST	+1 hour (DST start)	UTC+1h",
				"2019 	Sun, 27 Oct, 02:00	WEST → WET	-1 hour (DST end)	UTC",
				"2020	Sun, 29 Mar, 01:00	WET → WEST	+1 hour (DST start)	UTC+1h",
				"2020 	Sun, 25 Oct, 02:00	WEST → WET	-1 hour (DST end)	UTC"
			}
        },
        {
            new Tuple<string, string>("SGT", "Singapore Time"),
            new string[]{}
        },
        {
            new Tuple<string, string>("SAST", "South Africa Standard Time"),
            new string[]{}
        },
        {
            new Tuple<string, string>("CST", "China Standard Time"),
            new string[]{}
        },
        {
            new Tuple<string, string>("ICT", "Indochina Time"),
            new string[]{}
        },
    };

	foreach(var country in vals)
	{
		(@"<TimeZoneSchedule IDKey=""" + counter++ + @""">
	<Name>"+country.Key.Item1+ @"</Name>
	<Description>" +country.Key.Item2 + @"</Description>
	<ScheduleEvents>").Dump();
		foreach(string line in AddDateTimeMinValueLine(country.Value, startOffsets[country.Key.Item1]))
		{
		
			var foo = line.Split(new []{'\t'});
			var date = DateTime.ParseExact(
					(foo[1] + " " + foo[0]).Trim(), 
					"ddd, d MMM, HH:mm yyyy", 
					System.Globalization.CultureInfo.CurrentCulture);
			var offsetStr = new string(foo[4].Where(c => char.IsDigit(c) || c == '-'|| c == ':').ToArray());
			if (string.IsNullOrWhiteSpace(offsetStr) || offsetStr.Trim() == "-")	
			{
				offsetStr = "0";
			}
			TimeSpan offset = new TimeSpan(Int32.Parse(offsetStr),0,0);
			
			var timeUtc = date == DateTime.MinValue ? date : (date - offset);
			(@"		<ScheduleEvent>
				<Boundary>" + timeUtc + @"</Boundary>
				<TimeZone>" + (offset.Hours == 13 ? "13:00:00" : ((MilitaryTimeZoneNames)offset.Hours).ToString()) + @"</TimeZone>
			</ScheduleEvent>").Dump();
			
		}
		(@"	</ScheduleEvents>
</TimeZoneSchedule>").Dump();
	}
}

// Define other methods and classes here

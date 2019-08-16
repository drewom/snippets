<Query Kind="Statements" />

	const long ticks_per_second      = 10 * 1000 * 1000;
	const long ticks_per_minute      = ticks_per_second * 60;
	const long ticks_per_hour        = ticks_per_minute * 60;
	const long ticks_per_day         = ticks_per_hour   * 24;

	const int days_per_year      = 365;
	const int days_per_4_years   = days_per_year      * 4  + 1; // inc. extra leap day
	const int days_per_100_years = days_per_4_years   * 25 - 1; // inc. missing leap day
	const int days_per_400Years  = days_per_100_years * 4  + 1; // inc. extra leap day
	const int days_till_1601     = days_per_400Years  * 4;

	const long difference_between_dotnet_ticks_and_filetime = days_till_1601 * ticks_per_day;
	difference_between_dotnet_ticks_and_filetime.Dump();
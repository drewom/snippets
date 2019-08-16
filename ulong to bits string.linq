<Query Kind="Expression" />

string.Join(
	" ",
	BitConverter
		.GetBytes(DateTime.MaxValue.Ticks)
		.Reverse()
		.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))
)
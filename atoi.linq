<Query Kind="Program" />

void Main()
{
	var examples = new []{"1","+32","934134","   -00094313421","0","+0","-0","",null, "456564dafs"};
	examples.Select(atoi).Dump();
}
public int atoi(string s)
{
	int sign = +1;
	int magnitude = 0;
	if (s != null && s.Length > 0) 
	{
		int i = 0;
		
		while (char.IsWhiteSpace(s[i])) { i++; }
		
		if (s[i] == '-') { i++; sign = -1;}
		if (s[i] == '+') { i++; }
		while (i++ < s.Length)
		{
			char c = s[i-1];
			if (c >= '0' && c <= '9')
			{
				magnitude *= 10;
				magnitude += c - (int)'0';
			}
			else { break; }
		}
	}
	return sign * magnitude;
}
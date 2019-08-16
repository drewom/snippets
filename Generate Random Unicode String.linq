<Query Kind="Program" />

string RndString(Random random, int length)
{
	var plainText = new char[length];
	for (int i = 0; i < length; ++i)
	{
	    plainText[i] = (char)random.Next(char.MinValue, char.MaxValue);
	}
	return Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(new string(plainText)));
}

void Main()
{
	var random = new Random();
	for (int i = 0; i < 10000; ++i)
	{
		string result = RndString(random, 50);
		(result.Length.ToString() + ": " + result).Dump();
	}
}

// Define other methods and classes here

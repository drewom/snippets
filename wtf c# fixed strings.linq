<Query Kind="Program" />

void Main()
{
	const string foo = nameof(YYYYY);
	string foo2      = typeof(YYYYY).Name;
	
	nameof(YYYYY).Dump("nameof");
	typeof(YYYYY).Name.Dump("typeof");
	
	unsafe
	{
		fixed (char* ch1 = foo)
		fixed (char* ch2 = foo2)
		{
			for (int i = 0; i < foo.Length; ++i)
			{
				*(ch1 + i) = 'o';
				*(ch2 + i) = 'x';
			}		
		}
	}
	// wtf!
	nameof(YYYYY).Dump("nameof");
	typeof(YYYYY).Name.Dump("typeof");

}

class YYYYY{}
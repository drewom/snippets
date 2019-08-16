<Query Kind="Program" />

void Main()
{
	Tuple<string,string>[] values =  
		{
			new Tuple<string,string>("word",  "wrdo"),
		    new Tuple<string,string>("mary",  "army"),
		    new Tuple<string,string>("stop",  "tops"),
		    new Tuple<string,string>("boat",  "btoa"),
		    new Tuple<string,string>("pure",  "in"),
		    new Tuple<string,string>("fill",  "fil"),
		    new Tuple<string,string>("b",     "bbb"),
		    new Tuple<string,string>("ccc",   "ccccccc"),
		    new Tuple<string,string>("a",     "a"),
		    new Tuple<string,string>("sleep", "slep")
		};
		
	foreach(var pair in values)
	{
		(pair.Item1 + ", " + pair.Item2 + " = " + checkAnagram(pair.Item1, pair.Item2).ToString().ToLower()).Dump();
	}
}

public static bool checkAnagram(string first, string second)
{   
    foreach(char ch in first)
	{
        int index = second.IndexOf(ch);
        if(index >= 0)
		{
            second = second.Remove(index, 1);
        }
		else
		{
            return false;
        }
    }
   
    return second.Length == 0 ? true : false;
}
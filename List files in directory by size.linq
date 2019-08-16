<Query Kind="Expression" />

string.Join("\n", Directory.GetFiles(@"C:\Test\player.swf.decompiled", "*.as", SearchOption.AllDirectories)
		 .Select(name => new FileInfo(name))
		 .OrderByDescending(file => file.Length)
		 .Select(file => file.Name.PadRight(31,' ') + file.Length.ToString("N0").PadLeft(8,' ') + " bytes"))
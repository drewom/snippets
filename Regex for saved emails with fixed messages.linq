<Query Kind="Statements" />


Directory
.GetFiles(@"\\Domainblade01\FolderRedirection\DOMalley\Desktop\Email FIX Test")
.Select(filepath => Regex.Match(File.ReadAllText(filepath, System.Text.Encoding.ASCII), @"=0155=3D([^=01]*)=01").Groups[1].Value)
.Where(x => !String.IsNullOrWhiteSpace(x))
.Where(x => !x.EndsWith("LI"))
.Distinct()
.Dump();

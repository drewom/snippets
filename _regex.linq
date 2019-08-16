<Query Kind="Statements" />

string pathSource      = @"C:\test1";
string pathDestination = @"C:\test2\";

// Contract checks

// ensure the paths 
if (!pathSource.EndsWith("\\"))      { pathSource += "\\"; }
if (!pathDestination.EndsWith("\\")) { pathDestination += "\\"; }

var filesToConsider = Directory
		.GetFiles(pathSource, "*.*", SearchOption.AllDirectories)
		.Select(path => path.Replace(pathSource, ""))
		.ToArray();
		
foreach (var file in filesToConsider)
{
	var source      = new FileInfo(pathSource + file);
	var destination = new FileInfo(pathDestination + file);
	
	if (!destination.Exists || source.LastWriteTime > destination.LastWriteTime)
	{
        if (!Directory.Exists(destination.DirectoryName))
        {
            Directory.CreateDirectory(destination.DirectoryName);
        }
		File.Copy(source.FullName, destination.FullName, true);
		file.Dump();
	}
}
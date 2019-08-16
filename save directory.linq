<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.FileSystem.dll</Reference>
  <Namespace>System.IO.Compression</Namespace>
</Query>

string startPath = @"E:\Temp\Counterparty Reports\Output";
string zipPath = @"E:\Temp\Counterparty Reports\Output.zip";
string extractPath = @"E:\Temp\Counterparty Reports\Output - Extracted";

"ZipFile.CreateFromDirectory".Dump();
File.Delete(zipPath);
ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.NoCompression, false);

"ZipFile.ExtractToDirectory".Dump();
Directory.Delete(extractPath, true);
ZipFile.ExtractToDirectory(zipPath, extractPath);
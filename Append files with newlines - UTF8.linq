<Query Kind="Statements" />

var files = Directory.GetFiles(@"C:\PRO CLI Details\", "PRO CLI Details - *.csv").OrderBy(x=>x).Dump();

const int chunkSize = 2 * 1024; // 2KB (not needed for smaller files but )
using (var output = File.Create(@"C:\PRO CLI Details\PRO CLI Details.csv"))
{
    foreach (var file in files)
    {
        using (var input = File.OpenRead(file))
        {
            var buffer = new byte[chunkSize];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
            output.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Encoding.UTF8.GetBytes(Environment.NewLine).Length);
        }
    }
}
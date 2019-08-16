<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.dll</Reference>
</Query>

void Main()
{
    byte[] r1 = Zip("Google News watches more than 4500[4] news sources worldwide. Versions for more than 60 regions in 28 languages were available in March 2012. As of September 2015, service is offered in the following 35 languages: Arabic, Bengali, Bulgarian, Cantonese, Chinese, Czech, Dutch, English, French, German, Greek, Hebrew, Hindi, Hungarian, Italian, Indonesian, Japanese, Korean, Latvian, Lithuanian, Malayalam, Norwegian, Polish, Portuguese, Romanian, Russian, Serbian, Spanish, Swedish, Tamil, Telugu, Thai, Turkish, Ukrainian and Vietnamese.[5]The service covers news articles appearing within the past 30 days on various news websites. In total, Google News aggregates content from more than 25,000 publishers.[6] For the English language, it covers about 4,500 sites;[7] for other languages, fewer. Its front page provides roughly the first 200 characters of the article and a link to its larger content. Websites may or may not require a subscription; sites requiring subscription are noted in the article description.[8]On December 1, 2009, Google announced changes to their \"first click free\" program,[9][clarification needed] which has been running since 2008 and allows users to find and read articles behind a paywall. The reader's first click to the content is free, and the number after that would be set by the content provider.[10]The layout of Google News underwent a major revision on May 16, 2011.On July 14, 2011, Google introduced \"Google News Badges,\"[11] which it later retired in October 2012.[12]Additionally in July 2011, the Sci/Tech section of the English Google News versions was split up into two sections: Science and Technology. It was announced that this section split would be performed on other language versions as well.[13] As of early 2013, this split had not been applied to all language versions of Google News.");
    string r2 = Unzip(r1);
	r2.Dump("Raw string, (size: " + r2.Length*sizeof(char) + " bytes)");
	SpliceText(Convert.ToBase64String(r1), 100).Dump("GZipped (Shown as Base64, size: " + r1.Length + " bytes)");
	
	((((decimal)r1.Length) / ((decimal)r2.Length*sizeof(char)) * 100).ToString("N1") + "%").Dump("Size reduction");
}


public static byte[] Zip(string str)
{
    var bytes = Encoding.UTF8.GetBytes(str);

    using (var msi = new MemoryStream(bytes))
    using (var mso = new MemoryStream()) 
	{
        using (var gs = new System.IO.Compression.GZipStream(mso, System.IO.Compression.CompressionMode.Compress)) {
            //msi.CopyTo(gs);
            CopyTo(msi, gs);
        }

        return mso.ToArray();
    }
}

public static string Unzip(byte[] bytes) 
{
    using (var msi = new MemoryStream(bytes))
    using (var mso = new MemoryStream()) 
	{
        using (var gs = new System.IO.Compression.GZipStream(msi, System.IO.Compression.CompressionMode.Decompress)) 
		{
            CopyTo(gs, mso);
        }

        return Encoding.UTF8.GetString(mso.ToArray());
    }
}

public static void CopyTo(Stream source, Stream dest) 
{
    byte[] bytes = new byte[1024*1024];

    int count;

    while ((count = source.Read(bytes, 0, bytes.Length)) != 0) 
	{
        dest.Write(bytes, 0, count);
    }
}
public static string SpliceText(string text, int lineLength) 
{
  return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
}
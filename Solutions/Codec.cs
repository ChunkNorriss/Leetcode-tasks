using System.Collections;

namespace Solutions;

public class Codec
{
    private const string BaseUrl = "http://tinyurl.com/";
    private readonly Hashtable hashToUrl = new();

    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        var hash = GetHash(longUrl);
        hashToUrl.Add(hash, longUrl);

        return BaseUrl + hash;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        if (!shortUrl.StartsWith(BaseUrl))
            return null;
        var hash = shortUrl[BaseUrl.Length..];
        return hashToUrl[hash] as string;
    }

    private static string GetHash(string longUrl)
    {
        return longUrl.GetHashCode().ToString("x8");
    }
}


// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));
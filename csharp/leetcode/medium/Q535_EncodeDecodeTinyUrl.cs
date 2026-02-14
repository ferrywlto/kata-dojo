using System.Text;

public class Q535_EncodeDecodeTinyUrl
{
    const string Prefix = "https://tinyurl.com/";
    Dictionary<string, string> _tinyUrl = [];
    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        var hash = longUrl.GetHashCode();
        var bytes = Encoding.UTF8.GetBytes(hash.ToString());
        var key = Convert.ToBase64String(bytes);
        if (_tinyUrl.TryGetValue(key, out var val))
        {
            return $"{Prefix}{val}";
        }
        else
        {
            _tinyUrl.Add(key, longUrl);
            return $"{Prefix}{key}";
        }
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        var key = shortUrl[Prefix.Length..];
        if (_tinyUrl.TryGetValue(key, out var val))
            return val;
        else
            return shortUrl;
    }

    public static TheoryData<string, string> TestData => new()
    {
        {"https://leetcode.com/problems/design-tinyurl", "https://leetcode.com/problems/design-tinyurl"}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = decode(encode(input));
        Assert.Equal(expected, actual);
    }
}

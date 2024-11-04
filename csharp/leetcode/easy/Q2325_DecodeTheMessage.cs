using System.Text;

public class Q2325_DecodeTheMessage
{
    // TC: O(n + m), n scale with length of key and m scale with length of message
    // SC: O(k + m), k is constant to 26 for decrypt dictionary and m scale with length of message for string builder 
    public string DecodeMessage(string key, string message)
    {
        var keyIdx = 0;
        var dict = new Dictionary<char, char>();
        foreach (var c in key)
        {
            if (c == ' ') continue;
            if (dict.TryAdd(c, (char)(keyIdx + 'a'))) keyIdx++;
        }
        var sb = new StringBuilder();
        foreach (var c in message)
        {
            if (c == ' ') sb.Append(' ');
            else sb.Append(dict[c]);
        }
        return sb.ToString();
    }
    public static List<object[]> TestData =>
    [
        ["the quick brown fox jumps over the lazy dog", "vkbs bs t suepuv", "this is a secret"],
        ["eljuxhpwnyrdgtqkviszcfmabo", "zwx hnfx lqantp mnoeius ycgk vcnjrdb", "the five boxing wizards jump quickly"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string message, string expected)
    {
        var actual = DecodeMessage(input, message);
        Assert.Equal(expected, actual);
    }
}
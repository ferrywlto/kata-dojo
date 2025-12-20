public class Q1910_RemoveAllOccurencesOfSubstring(ITestOutputHelper output)
{
    public string RemoveOccurrences(string s, string part)
    {
        while(true)
        {
            var idx = s.IndexOf(part);
            if(idx == -1) return s;
            else if(idx == 0)
            {
                s = s.Substring(part.Length);
            }
            else if(idx == s.Length - part.Length)
            {
                s = s.Substring(0, s.Length- part.Length);
            }
            else
            {
                s = s.Substring(0, idx) + s.Substring(idx + part.Length);
            }
            output.WriteLine($"current: {s}");
        }
    }
    public static TheoryData<string, string, string> TestData => new()
    {
        {"daabcbaabcbc", "abc", "dab"},
        {"axxxxyyyyb", "xy", "ab"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string substring, string expected)
    {
        var actual = RemoveOccurrences(input, substring);
        Assert.Equal(expected, actual);
    }
}

public class Q3438_FindValidPairOfAdjacentDigitsInString
{
    // TC: O(n), n scale with length of s
    // SC: O(m), m scale with unique characters in s
    public string FindValidPair(string s)
    {
        var frequencies = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            if (frequencies.TryGetValue(ch, out var val))
                frequencies[ch] = ++val;
            else
                frequencies.Add(ch, 1);
        }
        for (var j = 1; j < s.Length; j++)
        {
            var ch1 = s[j - 1];
            var ch2 = s[j];
            if (
                frequencies[ch1] == ch1 - '0'
                && frequencies[ch2] == ch2 - '0'
                && ch1 != ch2
            ) return ch1 + "" + ch2;
        }
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"2523533", "23"},
        {"221", "21"},
        {"22", ""},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = FindValidPair(input);
        Assert.Equal(expected, actual);
    }
}

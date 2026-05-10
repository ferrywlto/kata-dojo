public class Q3889_MirrorFrequencyDistance
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int MirrorFrequency(string s)
    {
        Span<int> charFreq = stackalloc int[26];
        Span<int> digitFreq = stackalloc int[10];

        for (var i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i])) digitFreq[s[i] - '0']++;
            else charFreq[s[i] - 'a']++;
        }

        var result = 0;
        for (var i = 0; i < charFreq.Length / 2; i++)
        {
            result += Math.Abs(charFreq[i] - charFreq[25 - i]);
        }

        for (var i = 0; i < digitFreq.Length / 2; i++)
        {
            result += Math.Abs(digitFreq[i] - digitFreq[9 - i]);
        }

        return result;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "ab1z9", 3 },
        { "4m7n", 2 },
        { "byby", 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MirrorFrequency(input);
        Assert.Equal(expected, actual);
    }
}

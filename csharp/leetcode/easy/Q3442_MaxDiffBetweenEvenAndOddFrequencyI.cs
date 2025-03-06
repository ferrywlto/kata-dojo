public class Q3442_MaxDiffBetweenEvenAndOddFrequencyI
{
    // TC: O(n + m), n scale with length of s and m scale with unique characters in s
    // SC: O(m)
    public int MaxDifference(string s)
    {
        var freq = new Dictionary<char, int>();
        var evenMin = int.MaxValue;
        var oddMax = 1;

        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            if (freq.TryGetValue(ch, out var val)) freq[ch] = ++val;
            else freq.Add(ch, 1);
        }
        foreach (var p in freq)
        {
            var count = p.Value;
            if (count % 2 == 0 && count < evenMin) evenMin = count;
            else if (count % 2 == 1 && count > oddMax) oddMax = count;
        }
        return oddMax - evenMin;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aaaaabbc", 3},
        {"abcabcab", 1},
        {"yzyyys", -3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MaxDifference(input);
        Assert.Equal(expected, actual);
    }
}
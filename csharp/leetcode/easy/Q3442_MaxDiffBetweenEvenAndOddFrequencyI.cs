public class Q3442_MaxDiffBetweenEvenAndOddFrequencyI
{
    // TC: O(n), n scale with length of s
    // SC: O(1)
    public int MaxDifference(string s)
    {
        var freq = new int[26];
        var evenMin = int.MaxValue;
        var oddMax = 1;

        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            freq[ch - 'a']++;
        }
        for (var j = 0; j < freq.Length; j++)
        {
            var count = freq[j];
            if(count == 0) continue;
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
public class Q3090_MaxLengthSubstringWithTwoOccurences
{
    // TC: O(n^2), n scale with length of s with expansion technique
    // SC: O(1), space used does not scale with input
    public int MaximumLengthSubstring(string s)
    {
        var freq = new int[26];
        var maxLen = 0;
        var currLen = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (i + maxLen >= s.Length) break;

            for (var j = i; j < s.Length; j++)
            {
                var ch = s[j];
                var idx = ch - 'a';
                if (freq[idx] < 2)
                {
                    freq[idx]++;
                    currLen++;
                }
                else break;
            }
            if (currLen > maxLen) maxLen = currLen;
            currLen = 0;
            freq = new int[26];
        }
        if (currLen > maxLen) maxLen = currLen;
        return maxLen;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abcdddbca", 5},
        {"bcbbbcba", 4},
        {"aaaa", 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MaximumLengthSubstring(input);
        Assert.Equal(expected, actual);
    }
}
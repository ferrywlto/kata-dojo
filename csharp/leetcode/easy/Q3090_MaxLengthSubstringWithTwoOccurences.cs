public class Q3090_MaxLengthSubstringWithTwoOccurences
{
    // TC: O(n), n scale with length of s with sliding window technique
    // SC: O(1), space used does not scale with input
    public int MaximumLengthSubstring(string s)
    {
        var freq = new int[26];
        var maxLen = 0;
        var headIdx = 0;

        for (var tailIdx = 0; tailIdx < s.Length; tailIdx++)
        {
            var ch = s[tailIdx];
            var idx = ch - 'a';

            freq[idx]++;
            // What I was thinking but can't figure out how to do it.
            while (freq[idx] > 2)
            {
                freq[s[headIdx] - 'a']--;
                headIdx++;
            }

            var len = tailIdx - headIdx + 1;
            if (len > maxLen) maxLen = len;
        }

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

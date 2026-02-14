public class Q2937_MakeThreeStringsEqual
{
    // TC: O(n), n scale with min length in s1,s2,s3
    // SC: O(1), space used does not scale with input
    public int FindMinimumOperations(string s1, string s2, string s3)
    {
        var minLen = Math.Min(s1.Length, s2.Length);
        minLen = Math.Min(minLen, s3.Length);

        var longestPrefixIdx = -1;
        for (var i = 0; i < minLen; i++)
        {
            if (s1[i] != s2[i] || s1[i] != s3[i]) break;

            longestPrefixIdx = i;
        }

        if (longestPrefixIdx == -1) return -1;

        var idxLen = longestPrefixIdx + 1;
        var result = s1.Length - idxLen;
        result += s2.Length - idxLen;
        result += s3.Length - idxLen;
        return result;
    }
    public static TheoryData<string, string, string, int> TestData => new()
    {
        {"abc", "abb", "ab", 2},
        {"dac", "bac", "cac", -1},
        {"a", "a", "a", 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, string input3, int expected)
    {
        var actual = FindMinimumOperations(input1, input2, input3);
        Assert.Equal(expected, actual);
    }
}

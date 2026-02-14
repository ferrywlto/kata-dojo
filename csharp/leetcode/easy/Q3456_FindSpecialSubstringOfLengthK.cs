public class Q3456_FindSpecialSubstringOfLengthK
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not sacle with input
    public bool HasSpecialSubstring(string s, int k)
    {
        var currentLength = 1;
        var maxLen = 1;

        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] != s[i - 1])
            {
                if (currentLength > maxLen)
                {
                    maxLen = currentLength;
                }
                if (currentLength == k) return true;
                currentLength = 1;
            }
            else currentLength++;
        }
        if (currentLength > maxLen)
        {
            maxLen = currentLength;
        }
        if (currentLength == k) return true;
        return maxLen == k;
    }
    public static TheoryData<string, int, bool> TestData => new()
    {
        {"aaabaaa", 3, true},
        {"abc", 2, false},
        {"abbbc", 3, true},
        {"abbbc", 2, false},
        {"bbbc", 3, true},
        {"abbb", 3, true},
        {"bbbb", 3, false},
        {"bbb", 3, true},
        {"bb", 3, false},
        {"afc", 3, false},
        {"aiheddfej", 1, true},
        {"iijgj", 1, true},
        {"jjbbbaaf", 1, true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, bool expected)
    {
        var actual = HasSpecialSubstring(input, k);
        Assert.Equal(expected, actual);
    }
}

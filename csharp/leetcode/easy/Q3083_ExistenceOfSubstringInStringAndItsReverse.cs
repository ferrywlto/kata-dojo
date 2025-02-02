public class Q3083_ExistenceOfSubstringInStringAndItsReverse
{
    // TC: O(n^2), n scale with length of s
    // SC: O(1), space used does not scale with input
    public bool IsSubstringPresent(string s)
    {
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == s[i + 1]) return true;
            else
            {
                for (var j = s.Length - 1; j >= 1; j--)
                {
                    if (s[i] == s[j] && s[i + 1] == s[j - 1]) return true;
                }
            }
        }
        return false;
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"leetcode", true},
        {"abcba", true},
        {"abcd", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsSubstringPresent(input);
        Assert.Equal(expected, actual);
    }
}
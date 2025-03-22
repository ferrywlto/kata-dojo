public class Q680_ValidPalindromeII
{
    // use two pointers approach
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public bool ValidPalindrome(string s)
    {
        var startIdx = 0;
        var endIdx = s.Length - 1;
        while (startIdx < endIdx)
        {
            if (s[startIdx] != s[endIdx])
            {
                return IsPalindromeRange(s, startIdx + 1, endIdx) || IsPalindromeRange(s, startIdx, endIdx - 1);
            }

            startIdx++;
            endIdx--;
        }
        return true;
    }
    private bool IsPalindromeRange(string s, int i, int j)
    {
        while (i < j)
        {
            if (s[i] != s[j]) return false;
            i++;
            j--;
        }
        return true;
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"aba", true},
        {"abca", true},
        {"abc", false},
        {"aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga", true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = ValidPalindrome(input);
        Assert.Equal(expected, actual);
    }
}
class Q1332_RemovePalindromicSubsequences
{
    // TC: O(n), n is length of s
    // SC: O(1), no space used in operation
    public int RemovePalindromeSub(string s)
    {
        if (IsPalindrome(s)) return 1;
        // this is due to the constraint of subsequece definition
        // A string is a subsequence of a given string if it is generated by deleting some characters of a given string without changing its order. Note that a subsequence does not necessarily need to be contiguous.
        // That means we can delete all 'a' or 'b' in a step and since the character is either 'a' or 'b', it must be a palindrome of when all 'a' or all 'b' deleted.
        // Thus the most possible step is 2
        var count = 0;
        if (s.Contains('a')) count++;
        if (s.Contains('b')) count++;
        return count;
    }
    public bool IsPalindrome(string sb)
    {
        var times = sb.Length / 2;
        for(var i=0; i<times; i++)
        {
            if (sb[i] != sb[^(i + 1)]) return false;
        }
        return true;
    }
}
class Q1332_RemovePalindromicSubsequencesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["ababa", 1],
        ["abb", 2],
        ["baabb", 2],
    ];
}
public class Q1332_RemovePalindromicSubsequencesTests
{
    [Theory]
    [ClassData(typeof(Q1332_RemovePalindromicSubsequencesTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1332_RemovePalindromicSubsequences();
        var actual = sut.RemovePalindromeSub(input);
        Assert.Equal(expected, actual);
    }
}
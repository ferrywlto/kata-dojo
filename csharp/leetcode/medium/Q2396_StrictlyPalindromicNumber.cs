public class Q2396_StrictlyPalindromicNumber
{
    // TC: O(1)
    // SC: O(1)
    public bool IsStrictlyPalindromic(int n)
    {
        return false;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        {9, false},
        {4, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = IsStrictlyPalindromic(input);
        Assert.Equal(expected, actual);
    }
}
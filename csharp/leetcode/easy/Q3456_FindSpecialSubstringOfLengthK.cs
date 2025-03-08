public class Q3456_FindSpecialSubstringOfLengthK
{
    public bool HasSpecialSubstring(string s, int k)
    {
        return false;
    }
    public static TheoryData<string, int, bool> TestData => new()
    {
        {"aaabaaa", 3, true},
        {"abc", 2, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, bool expected)
    {
        var actual = HasSpecialSubstring(input, k);
        Assert.Equal(expected, actual);
    }
}
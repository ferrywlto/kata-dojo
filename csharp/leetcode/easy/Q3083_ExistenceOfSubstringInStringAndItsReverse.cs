public class Q3083_ExistenceOfSubstringInStringAndItsReverse
{
    public bool IsSubstringPresent(string s)
    {
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
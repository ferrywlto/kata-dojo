using Microsoft.VisualBasic;

public class Q2839_CheckIfStringsCanMadeEqualWithOperationsI
{
    public bool CanBeEqual(string s1, string s2)
    {
        return false;
    }
    public static TheoryData<string, string, bool> TestData => new()
    {
        {"abcd", "cdab", true},
        {"abcd", "cdab", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, bool expected)
    {
        var actual = CanBeEqual(input1, input2);
        Assert.Equal(expected, actual);
    }
}
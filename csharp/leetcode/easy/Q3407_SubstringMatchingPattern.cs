public class Q3407_SubstringMatchingPattern
{
    public bool HasMatch(string s, string p)
    {
        return false;
    }
    public static TheoryData<string, string, bool> TestData => new()
    {
        {"leetcode", "ee*e", true},
        {"car", "c*v", false},
        {"luck", "u*", true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, bool expected)
    {
        var actual = HasMatch(input1, input2);
        Assert.Equal(expected, actual);
    }
}
public class Q2937_MakeThreeStringsEqual
{
    public int FindMinimumOperations(string s1, string s2, string s3)
    {
        return 0;
    }
    public static TheoryData<string, string, string, int> TestData => new()
    {
        {"abc", "abb", "ab", 2},
        {"dac", "bac", "cac", -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, string input3, int expected)
    {
        var actual = FindMinimumOperations(input1, input2, input3);
        Assert.Equal(expected, actual);
    }
}
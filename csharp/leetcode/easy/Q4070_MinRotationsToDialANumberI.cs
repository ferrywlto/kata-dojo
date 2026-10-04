public class Q4070_MinRotationsToDialANumberI
{
    public int MinRotations(string s)
    {
        return 0;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "0192837465", 25 },
        { "1200210200", 12 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinRotations(input);
        Assert.Equal(expected, actual);
    }
}

public class Q2696_MinStringLengthAfterRemovingSubstrings
{
    public int MinLength(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"ABFCACDB", 2},
        {"ACBBD", 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinLength(input);
        Assert.Equal(expected, actual);
    }
}
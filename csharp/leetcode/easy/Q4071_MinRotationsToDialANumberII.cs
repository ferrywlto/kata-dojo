public class Q4071_MinRotationsToDialANumberII
{
    public int MinRotations(int n, string s)
    {
        return 0;
    }

    public static TheoryData<int, string, int> TestData => new()
    {
        { 4, "1502", 9 },
        { 4, "2916", 12 },
        { 4, "4219", 6 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, string input, int expected)
    {
        var actual = MinRotations(n, input);
        Assert.Equal(expected, actual);
    }
}

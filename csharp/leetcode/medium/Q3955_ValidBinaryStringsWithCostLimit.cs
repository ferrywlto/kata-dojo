public class Q3955_ValidBinaryStringsWithCostLimit
{
    public IList<string> GenerateValidStrings(int n, int k)
    {
        return [];
    }

    public static TheoryData<int, int, List<string>> TestData => new()
    {
        { 3, 1, ["000", "010", "100"] },
        { 1, 0, ["0", "1"] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int k, List<string> expected)
    {
        var actual = GenerateValidStrings(n, k);
        Assert.Equal(expected, actual);
    }
}

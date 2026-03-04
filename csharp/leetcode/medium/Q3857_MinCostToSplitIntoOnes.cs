public class Q3857_MinCostToSplitIntoOnes
{
    public int MinCost(int n)
    {
        return 0;
    }

    public static TheoryData<int, int> TestData => new() { { 3, 3 }, { 4, 6 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MinCost(input);
        Assert.Equal(expected, actual);
    }
}

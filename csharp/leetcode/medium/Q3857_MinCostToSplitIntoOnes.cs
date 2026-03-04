public class Q3857_MinCostToSplitIntoOnes
{
    // TC: O(n), n scale with input
    // SC: O(1), space used does not scale with input
    public int MinCost(int n)
    {
        return Cost(n);
    }

    private int Cost(int n)
    {
        if (n == 2) return 1;
        if (n == 1) return 0;
        if (n % 2 == 0)
            return 2 * (n - 2) + Cost(2) + Cost(n - 2);

        return (n - 1) + Cost(1) + Cost(n - 1);
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

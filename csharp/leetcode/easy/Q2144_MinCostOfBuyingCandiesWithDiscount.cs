public class Q2144_MinCostOfBuyingCandiesWithDiscount
{
    // TC: O(nlogn), n scale with length of cost, dominant by Array.Sort();
    // SC: O(1), space used does not scale with input
    public int MinimumCost(int[] cost)
    {
        switch (cost.Length)
        {
            case 1:
                return cost[0];
            case 2:
                return cost[0] + cost[1];
        }

        Array.Sort(cost);
        var result = 0;
        for (var i = cost.Length - 1; i >= 0; i -= 3)
        {
            if (i == 0) result += cost[0];
            else result += cost[i] + cost[i - 1];
        }
        return result;
    }

    public static TheoryData<int[], int> TestData =>
        new()
        {
            { [1, 2, 3], 5 },
            { [6, 5, 7, 9, 2, 2], 23 },
            { [6, 5, 7, 9, 2, 2, 2], 25 },
            { [6, 5, 7, 9, 2, 2, 2, 2], 27 },
            { [5, 5], 10 }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumCost(input);
        Assert.Equal(expected, actual);
    }
}

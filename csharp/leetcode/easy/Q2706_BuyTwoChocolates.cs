public class Q2706_BuyTwoChocolates
{
    // TC: O(n), n sacle with length of prices
    // SC: O(1), space used doest not scale with input
    public int BuyChoco(int[] prices, int money)
    {
        var smallest = int.MaxValue;
        var secondSmallest = int.MaxValue;
        for (var i = 0; i < prices.Length; i++)
        {
            if (prices[i] < smallest)
            {
                secondSmallest = smallest;
                smallest = prices[i];
            }
            else if (prices[i] < secondSmallest)
            {
                secondSmallest = prices[i];
            }
        }
        return smallest + secondSmallest > money
            ? money
            : money - secondSmallest - smallest;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[1, 2, 2], 3, 0},
        {[3, 2, 2], 3, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int money, int expected)
    {
        var actual = BuyChoco(input, money);
        Assert.Equal(expected, actual);
    }
}

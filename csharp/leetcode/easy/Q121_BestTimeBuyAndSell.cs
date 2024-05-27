class Q121_BestTimeBuyAndSellTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] { 7, 1, 5, 3, 6, 4 }, 5],
        [new int[] { 7, 1, 6, 3, 5, 4 }, 5],
        [new int[] { 7, 1, 6, 1, 7, 0, 9, 5, 4 }, 9],
        [new int[] { 7, 6, 4, 3, 1 }, 0],
        [new int[] { 1 }, 0],
        [new int[] { 1, 2 }, 1],
        [new int[] { 1, 2, 4 }, 3],
        [new int[] { 2, 4, 1 }, 2],
        [new int[] { 2, 1, 2, 0, 1 }, 1],
        [new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 4],
    ];
}

public class Q121_BestTimeBuyAndSellTests
{
    [Theory]
    [ClassData(typeof(Q121_BestTimeBuyAndSellTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q121_BestTimeBuyAndSell();
        var actual = sut.MaxProfit(input);
        Assert.Equal(expected, actual);
    }
}
/*
Constraints:

1 <= prices.length <= 10^5
0 <= prices[i] <= 10^4
*/
class Q121_BestTimeBuyAndSell
{
    // TC: O(n), SC:O(1)
    public int MaxProfit(int[] prices)
    {
        if (prices.Length == 1) return 0;

        var smallest = prices[0];
        var maxProfit = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] < smallest)
            {
                smallest = prices[i];
            }
            else
            {
                var diff = prices[i] - smallest;
                if (diff > maxProfit)
                {
                    maxProfit = diff;
                }
            }
        }
        return maxProfit;
    }


    // It works, but this O(n^2) approach will timeout 
    public int MaxProfit_Inefficient(int[] prices)
    {
        var profit = 0;
        for (var i = 0; i < prices.Length - 1; i++)
        {
            for (var j = i + 1; j < prices.Length; j++)
            {
                var temp = prices[j] - prices[i];
                if (temp > profit)
                {
                    profit = temp;
                }
            }
        }
        return profit;
    }
}
public class Q121_BestTimeBuyAndSellTests {
    [Theory]
    [InlineData(new int[]{7,1,5,3,6,4}, 5)]
    [InlineData(new int[]{7,6,4,3,1}, 0)]
    public void OfficialTestCases(int[] input, int expected) {
        var sut = new Q121_BestTimeBuyAndSell();
        var actual = sut.MaxProfit(input);
        Assert.Equal(expected, actual);
    }
}
/*
Constraints:

1 <= prices.length <= 105
0 <= prices[i] <= 104
*/
public class Q121_BestTimeBuyAndSell {
    public int MaxProfit(int[] prices) {
        return 0;    
    }
}
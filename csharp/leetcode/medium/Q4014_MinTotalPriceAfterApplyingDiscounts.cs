public class Q4014_MinTotalPriceAfterApplyingDiscounts
{
    public double MinPrice(int[] prices, int[] discounts)
    {
        return 0;
    }

    public static TheoryData<int[], int[], double> TestData => new()
    {
        {[10,30,21], [50,60], 32.50000},
        {[100,70], [10,40,50], 92.00000},
        {[7,3,9], [100,100],3.00000},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] p, int[] d, double expected)
    {
        var actual = MinPrice(p, d);
        Assert.Equal(expected, actual);
    }
}

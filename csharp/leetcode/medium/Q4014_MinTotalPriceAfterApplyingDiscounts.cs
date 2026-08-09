public class Q4014_MinTotalPriceAfterApplyingDiscounts
{
    // TC: O(p log p + d)
    // SC: O(d)
    public double MinPrice(int[] prices, int[] discounts)
    {
        Array.Sort(prices);

        // Since discounts can only be 0 - 100, using a histogram avoid sort.
        Span<int> d = stackalloc int[101];
        foreach (var discount in discounts) d[discount]++;

        var pIdx = prices.Length - 1;
        var highestDiscountIdx = 100;

        long result = 0;
        while (pIdx >= 0)
        {
            while (highestDiscountIdx >= 0 && d[highestDiscountIdx] == 0) highestDiscountIdx--;

            // trick: multiply 100 first for integer arithmetic, then only do floating point division once at the end.
            var percent = 100;
            if (highestDiscountIdx >= 0)
            {
                d[highestDiscountIdx]--;
                percent -= highestDiscountIdx;
            }

            result += prices[pIdx--] * percent;
        }
        return result / 100.0;
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

class Q1475_FinalPricesWithSpecialDiscountInShop
{
    // TC: O(n^2), it cannot be faster due to question constraints
    // SC: O(1), the space used is fixed, array items are updated in-place and
    public int[] FinalPrices(int[] prices)
    {
        // worst case it will be O((n-1)+(n-2)+(n-3)...) => O(n^2)/2 => O(n^2) if we use brute force approach
        // but we also cannot use binary search as the array cannot be sorted
        for (var i = 0; i < prices.Length - 1; i++)
        {
            var lower = FindFirstLower(prices, i + 1, prices[i]);
            prices[i] = prices[i] - lower;
        }
        return prices;
    }
    public int FindFirstLower(int[] input, int startIdx, int target)
    {
        for (var i = startIdx; i < input.Length; i++)
        {
            if (input[i] <= target) return input[i];
        }
        return 0;
    }
}
class Q1475_FinalPricesWithSpecialDiscountInShopTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {8,4,6,2,3}, new int[] {4,2,4,2,3}],
        [new int[] {1,2,3,4,5}, new int[] {1,2,3,4,5}],
        [new int[] {10,1,1,6}, new int[] {9,0,1,6}],
    ];
}
public class Q1475_FinalPricesWithSpecialDiscountInShopTests
{
    [Theory]
    [ClassData(typeof(Q1475_FinalPricesWithSpecialDiscountInShopTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1475_FinalPricesWithSpecialDiscountInShop();
        var actual = sut.FinalPrices(input);
        Assert.Equal(expected, actual);
    }
}

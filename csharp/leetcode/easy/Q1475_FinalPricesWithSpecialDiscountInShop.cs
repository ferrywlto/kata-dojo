
class Q1475_FinalPricesWithSpecialDiscountInShop
{
    public int[] FinalPrices(int[] prices)
    {
        return [];
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
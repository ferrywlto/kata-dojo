public class Q2706_BuyTwoChocolates
{
    public int BuyChoco(int[] prices, int money)
    {
        return 0;
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

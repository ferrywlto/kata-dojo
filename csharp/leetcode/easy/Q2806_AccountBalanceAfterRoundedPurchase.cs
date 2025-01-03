public class Q2806_AccountBalanceAfterRoundedPurchase
{
    public int AccountBalanceAfterPurchase(int purchaseAmount)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {9, 90},
        {15, 80},
        {10, 90},
        {95, 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = AccountBalanceAfterPurchase(input);
        Assert.Equal(expected, actual);
    }
}
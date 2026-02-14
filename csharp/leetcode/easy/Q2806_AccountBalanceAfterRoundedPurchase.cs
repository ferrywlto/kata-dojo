public class Q2806_AccountBalanceAfterRoundedPurchase
{
    // TC: O(1) obviously
    // SC: O(1) same as time
    public int AccountBalanceAfterPurchase(int purchaseAmount)
    {
        var digit = purchaseAmount % 10;
        var x = digit >= 5 ? 10 : 0;
        purchaseAmount = purchaseAmount - digit + x;

        return 100 - purchaseAmount;
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

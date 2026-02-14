class Q1716_CalculateMoneyInLeetcodeBank
{
    // TC: O(n), where n is size of n
    // SC: O(1), space use is fixed
    public int TotalMoney(int n)
    {
        const int sumOfWeek = 28;
        var multiplier = 0;
        var result = 0;
        while (n > 7)
        {
            n -= 7;
            result += sumOfWeek + 7 * multiplier;
            multiplier++;
        }
        for (var i = 1; i <= n; i++)
        {
            result += i + multiplier;
        }
        return result;
    }
}
class Q1716_CalculateMoneyInLeetcodeBankTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [4,10],
        [10,37],
        [20,96],
    ];
}
public class Q1716_CalculateMoneyInLeetcodeBankTests
{
    [Theory]
    [ClassData(typeof(Q1716_CalculateMoneyInLeetcodeBankTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1716_CalculateMoneyInLeetcodeBank();
        var actual = sut.TotalMoney(input);
        Assert.Equal(expected, actual);
    }
}

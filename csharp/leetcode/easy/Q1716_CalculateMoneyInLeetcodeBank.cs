class Q1716_CalculateMoneyInLeetcodeBank
{
    public int TotalMoney(int n)
    {
        return 0;
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
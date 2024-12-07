public class Q2591_DistributeMoneyToMaxChildren
{
    public int DistMoney(int money, int children) 
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [20, 3, 1],
        [16, 2, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int child, int expected)
    {
        var actual = DistMoney(input, child);
        Assert.Equal(expected, actual);
    }
}
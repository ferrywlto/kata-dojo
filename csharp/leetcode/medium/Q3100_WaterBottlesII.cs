public class Q3100_WaterBottlesII
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {13, 6, 15},
        {10, 3, 13},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int numBottles, int numExchange, int expected)
    {
        var actual = MaxBottlesDrunk(numBottles, numExchange);
        Assert.Equal(expected, actual);
    }
}

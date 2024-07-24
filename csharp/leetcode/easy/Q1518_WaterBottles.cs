
class Q1518_WaterBottles
{
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        return 0;
    }
}
class Q1518_WaterBottlesTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [9,3,13],
        [15,4,19],
    ];
}
public class Q1518_WaterBottlesTests
{
    [Theory]
    [ClassData(typeof(Q1518_WaterBottlesTestData))]
    public void OfficialTestCases(int input, int k, int expected)
    {
        var sut = new Q1518_WaterBottles();
        var actual = sut.NumWaterBottles(input, k);
        Assert.Equal(expected, actual);
    }
}
public class Q3100_WaterBottlesII
{
    // TC: O(n), n scale with size of numBottles
    // SC: O(1), space used does not scale with input
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        var result = numBottles;
        var emptyBottles = numBottles;
        while (emptyBottles >= numExchange)
        {
            emptyBottles = emptyBottles + 1 - numExchange++;
            result++;
        }
        return result;
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

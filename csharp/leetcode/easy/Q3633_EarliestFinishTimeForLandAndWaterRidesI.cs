public class Q3633_EarliestFinishTimeForLandAndWaterRidesI
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        return 0;
    }
    public static TheoryData<int[], int[], int[], int[], int> TestData => new()
    {
        {[2,8], [4,1], [6], [3], 9},
        {[5], [3], [1], [10], 14},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration, int expected)
    {
        var actual = EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration);
        Assert.Equal(expected, actual);
    }
}

public class Q3633_EarliestFinishTimeForLandAndWaterRidesI
{
    // TC: O(n + m), where n is the number of land rides and m is the number of water rides.
    // SC: O(1), since we are using a constant amount of space for variables.
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        var landLen = landStartTime.Length;
        var waterLen = waterStartTime.Length;

        var landEarliestFinish = int.MaxValue;

        for (var i = 0; i < landLen; i++)
        {
            landEarliestFinish = Math.Min(landEarliestFinish, landStartTime[i] + landDuration[i]);
        }

        var landFirstEarliestFinish = int.MaxValue;
        for (var i = 0; i < waterLen; i++)
        {
            /* Get the possible finish time for water ride,             
            if land finish before water starts, just land end + water duration, 
            else water start + water duration 
            */
            var temp = Math.Max(waterStartTime[i], landEarliestFinish) + waterDuration[i];

            landFirstEarliestFinish = Math.Min(landFirstEarliestFinish, temp);
        }

        var waterEarliestFinish = int.MaxValue;
        for (var i = 0; i < waterLen; i++)
        {
            waterEarliestFinish = Math.Min(waterEarliestFinish, waterStartTime[i] + waterDuration[i]);
        }

        var waterFirstEarliestFinish = int.MaxValue;
        for (var i = 0; i < landLen; i++)
        {
            /* Get the possible finish time for land ride,             
            if water finish before land starts, just water end + land duration, 
            else land start + land duration 
            */
            var temp = Math.Max(landStartTime[i], waterEarliestFinish) + landDuration[i];

            waterFirstEarliestFinish = Math.Min(waterFirstEarliestFinish, temp);
        }

        return Math.Min(landFirstEarliestFinish, waterFirstEarliestFinish);
    }

    public static TheoryData<int[], int[], int[], int[], int> TestData => new()
    {
        {[2,8], [4,1], [6], [3], 9},
        {[5], [3], [1], [10], 14},
        {[99], [59], [99,54], [85,20], 158},
        {[94,46], [59,97], [7], [13], 143}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration, int expected)
    {
        var actual = EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration);
        Assert.Equal(expected, actual);
    }
}

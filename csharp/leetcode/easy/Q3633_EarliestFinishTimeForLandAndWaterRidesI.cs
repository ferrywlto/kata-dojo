public class Q3633_EarliestFinishTimeForLandAndWaterRidesI(ITestOutputHelper output)
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        var landLen = landStartTime.Length;
        var waterLen = waterStartTime.Length;

        var landFinishTime = new int[landLen];
        for (var i = 0; i < landLen; i++)
        {
            landFinishTime[i] = landStartTime[i] + landDuration[i];
        }
        output.WriteLine($"Land Finish Times: {string.Join(", ", landFinishTime)}");
        var waterFinishTime = new int[waterLen];
        for (var i = 0; i < waterLen; i++)
        {
            waterFinishTime[i] = waterStartTime[i] + waterDuration[i];
        }
        output.WriteLine($"Water Finish Times: {string.Join(", ", waterFinishTime)}");
        var earliestFinish = int.MaxValue;

        for (var i = 0; i < landLen; i++)
        {
            for (var j = 0; j < waterLen; j++)
            {
                output.WriteLine("check: {0}, {1}, landF: {2}, waterStart: {3}", i, j, landFinishTime[i], waterStartTime[j]);

                if (landFinishTime[i] >= waterStartTime[j])
                {
                    // Immediate start land ride after water ride
                    var finishTime = landFinishTime[i] + waterDuration[j];
                    if (finishTime < earliestFinish)
                    {
                        earliestFinish = finishTime;
                    }
                }
                else
                {
                    // Need to wait for water ride to start and get earliest finish time
                    if (waterFinishTime[j] < earliestFinish)
                    {
                        earliestFinish = waterFinishTime[j];
                    }
                }
            }
        }

        for (var i = 0; i < waterLen; i++)
        {
            for (var j = 0; j < landLen; j++)
            {
                output.WriteLine("check: {0}, {1}, waterF: {2}, landStart: {3}", i, j, waterFinishTime[i], landStartTime[j]);
                if (waterFinishTime[i] >= landStartTime[j])
                {
                    var finishTime = waterFinishTime[i] + landDuration[j];
                    if (finishTime < earliestFinish)
                    {
                        earliestFinish = finishTime;
                    }
                }
                else
                {
                    if (landFinishTime[j] < earliestFinish)
                    {
                        earliestFinish = landFinishTime[j];
                    }
                }
            }
        }
        return earliestFinish;
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

public class Q3633_EarliestFinishTimeForLandAndWaterRidesI(ITestOutputHelper output)
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        var landLen = landStartTime.Length;
        var waterLen = waterStartTime.Length;

        var landFinishTime = new int[landLen];
        
        var earliestFinish = int.MaxValue;
        for (var i = 0; i < landLen; i++)
        {
            landFinishTime[i] = landStartTime[i] + landDuration[i];
            for (var j = 0; j < waterLen; j++)
            {
                var landFirstFinishTime = landStartTime[i] + landDuration[i];
                output.WriteLine("land first Finish Times[{0}]: {1}", i, landFirstFinishTime);
                if (landFirstFinishTime >= waterStartTime[j])
                {
                    landFirstFinishTime += waterDuration[j];
                }
                else
                {
                    landFirstFinishTime = waterStartTime[j] + waterDuration[j];
                }
                output.WriteLine("land first Finish Times: {0}, earliestFinish: {1}", landFirstFinishTime, earliestFinish);
                earliestFinish = Math.Min(earliestFinish, landFirstFinishTime);

                var waterFirstFinishTime = waterStartTime[j] + waterDuration[j];
                output.WriteLine("water first Finish Times[{0}]: {1}", i, waterFirstFinishTime);
                if (waterFirstFinishTime >= landStartTime[i])
                {
                    waterFirstFinishTime += landDuration[i];
                }
                else
                {
                    waterFirstFinishTime = landStartTime[i] + landDuration[i];
                }
                output.WriteLine("water first Finish Times: {0}, earliestFinish: {1}", waterFirstFinishTime, earliestFinish);                
                earliestFinish = Math.Min(earliestFinish, waterFirstFinishTime);
            }
        }
        // output.WriteLine($"Land Finish Times: {string.Join(", ", landFinishTime)}");
        // var waterFinishTime = new int[waterLen];
        // for (var i = 0; i < waterLen; i++)
        // {
        //     waterFinishTime[i] = waterStartTime[i] + waterDuration[i];
        //     for (var j = 0; j < landLen; j++)
        //     {
        //         var finishTime = waterStartTime[i] + waterDuration[i];
        //         output.WriteLine("water first Finish Times[{0}]: {1}", i, finishTime);
        //         if (finishTime >= landStartTime[j])
        //         {
        //             finishTime += landDuration[j];
        //         }
        //         else
        //         {
        //             finishTime = landStartTime[j] + landDuration[j];
        //         }
        //         output.WriteLine("water first Finish Times: {0}, earliestFinish: {1}", finishTime, earliestFinish);
        //         earliestFinish = Math.Min(earliestFinish, finishTime);
        //     }
        // }
        // output.WriteLine($"Water Finish Times: {string.Join(", ", waterFinishTime)}");
        
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

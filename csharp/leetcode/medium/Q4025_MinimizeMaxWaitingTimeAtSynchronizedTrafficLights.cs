public class Q4025_MinimizeMaxWaitingTimeAtSynchronizedTrafficLights
{
    public int MinPenalty(int period, int[] lights, int[] arrivalTime)
    {
        return 0;
    }

    public static TheoryData<int, int[], int[], int> TestData => new()
    {
        { 8, [2, 3], [2, 5, 8, 11], 5 },
        { 10, [3, 6, 8], [4, 9, 15], 1 },
        { 5, [2], [2, 3, 4, 5, 6], 3 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int period, int[] lights, int[] arrivalTime, int expected)
    {
        var actual = MinPenalty(period, lights, arrivalTime);
        Assert.Equal(expected, actual);
    }
}

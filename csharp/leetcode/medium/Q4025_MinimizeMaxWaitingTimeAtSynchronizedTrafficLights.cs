public class Q4025_MinimizeMaxWaitingTimeAtSynchronizedTrafficLights
{
    /*
     * Each car must be assigned to exactly one traffic light.
     * Multiple cars may be assigned to the same traffic light.
     * Any number of cars may cross the same traffic light simultaneously while it is green. Cars do not block or delay one another.
     *
     * Due to the above fact, we can only consider the light that have the longest duration of green light, thus minimal wait time.
     */
    // lights means green light duration
    // TC: O(n)
    // SC: O(1)
    public int MinPenalty(int period, int[] lights, int[] arrivalTime)
    {
        var result = int.MinValue;
        var longestGreenDuration = lights.Max();
        foreach (var time in arrivalTime)
        {
            var timeInPeriodArrival = time % period;
            var penalty = period - timeInPeriodArrival;
            if (timeInPeriodArrival >= longestGreenDuration && penalty >= result)
                result = penalty;
        }
        return result == int.MinValue ? 0 : result;
    }

    public static TheoryData<int, int[], int[], int> TestData => new()
    {
        { 8, [2, 3], [2, 5, 8, 11], 5 },
        { 10, [3, 6, 8], [4, 9, 15], 1 },
        { 5, [2], [2, 3, 4, 5, 6], 3 },
        { 2, [1, 1, 1, 1, 1], [30], 0}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int period, int[] lights, int[] arrivalTime, int expected)
    {
        var actual = MinPenalty(period, lights, arrivalTime);
        Assert.Equal(expected, actual);
    }
}

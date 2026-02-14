public class Q2651_CalculateDelayedArrivalTime
{
    // TC: O(1) obviously
    // SC: O(1)
    public int FindDelayedArrivalTime(int arrivalTime, int delayedTime)
    {
        return (arrivalTime + delayedTime) % 24;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {15, 5, 20},
        {13, 11, 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = FindDelayedArrivalTime(input1, input2);
        Assert.Equal(expected, actual);
    }
}

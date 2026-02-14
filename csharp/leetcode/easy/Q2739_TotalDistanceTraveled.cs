public class Q2739_TotalDistanceTraveled
{
    // TC: O(n), n scale with size of mainTank
    // SC: O(1), space used does not scale with input
    public int DistanceTraveled(int mainTank, int additionalTank)
    {
        var fuelUsed = 0;
        while (mainTank >= 5)
        {
            mainTank -= 5;
            fuelUsed += 5;
            if (additionalTank > 0)
            {
                additionalTank--;
                mainTank++;
            }
        }
        fuelUsed += mainTank;
        return fuelUsed * 10;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {5, 10, 60},
        {1, 2, 10},
        {9, 1, 100},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = DistanceTraveled(input1, input2);
        Assert.Equal(expected, actual);
    }
}

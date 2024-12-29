public class Q2739_TotalDistanceTraveled
{
    public int DistanceTraveled(int mainTank, int additionalTank)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {5, 10, 60},
        {1, 2, 10},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = DistanceTraveled(input1, input2);
        Assert.Equal(expected, actual);
    }
}
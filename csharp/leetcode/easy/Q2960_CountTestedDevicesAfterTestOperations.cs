public class Q2960_CountTestedDevicesAfterTestOperations
{
    public int CountTestedDevices(int[] batteryPercentages)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,1,2,1,3], 3},
        {[0,1,2], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountTestedDevices(input);
        Assert.Equal(expected, actual);
    }
}

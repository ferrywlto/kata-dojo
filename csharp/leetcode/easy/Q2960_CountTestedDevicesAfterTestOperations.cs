public class Q2960_CountTestedDevicesAfterTestOperations
{
    // TC: O(n), n scale with length of batteryPercentages
    // SC: O(1), space used does not scale with input
    public int CountTestedDevices(int[] batteryPercentages)
    {
        var tested = 0;
        for (var i = 0; i < batteryPercentages.Length; i++)
        {
            var device = batteryPercentages[i];
            if (device > 0)
            {
                device -= tested;
                if (device > 0) tested++;
            }
        }
        return tested;
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

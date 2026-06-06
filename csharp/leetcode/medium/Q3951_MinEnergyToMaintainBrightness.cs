public class Q3951_MinEnergyToMaintainBrightness
{
    public long MinEnergy(int n, int brightness, int[][] intervals)
    {
        return 0;
    }

    public static TheoryData<int, int, int[][], int> TestData => new()
    {
        { 5, 5, [[6, 12]], 14 },
        { 2, 1, [[0, 0], [2, 2]], 2 },
        { 4, 2, [[1, 3], [2, 4]], 4 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int brightness, int[][] intervals, int expected)
    {
        var actual = MinEnergy(n, brightness, intervals);
        Assert.Equal(expected, actual);
    }
}

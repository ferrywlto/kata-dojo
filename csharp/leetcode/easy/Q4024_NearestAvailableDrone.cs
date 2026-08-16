public class Q4024_NearestAvailableDrone
{
    public int NearestDrone(int[][] drones, int[] target)
    {
        return 0;
    }

    public static TheoryData<int[][], int[], int> TestData => new()
    {
        { [[0, 0, 8], [2, 2, 9]], [3, 4], 1 },
        { [[2, 1, 5], [4, 4, 5], [6, 6, 8]], [5, 5], 1 },
        { [[4, 4, 5]], [8, 6], -1}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] drones, int[] target, int expected)
    {
        var actual = NearestDrone(drones, target);
        Assert.Equal(expected, actual);
    }
}

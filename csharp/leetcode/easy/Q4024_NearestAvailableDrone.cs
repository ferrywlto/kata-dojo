public class Q4024_NearestAvailableDrone
{
    // TC: O(n)
    // SC: O(1)
    public int NearestDrone(int[][] drones, int[] target)
    {
        var resultIdx = -1;
        var minDistance = int.MaxValue;

        for (var i = 0; i < drones.Length; i++)
        {
            var drone = drones[i];
            var distance = Math.Abs(drone[0] - target[0]) + Math.Abs(drone[1] - target[1]);
            if (distance <= drone[2] && distance < minDistance)
            {
                minDistance = distance;
                resultIdx = i;
            }
        }
        return resultIdx;
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

public class Q3961_MaxSumOfDeviceRatings
{
    public long MaxRatings(int[][] units)
    {
        return 0;
    }

    public static TheoryData<int[][], long> TestData => new()
    {
        { [[1, 3], [2, 2]], 4 },
        { [[1, 2, 3], [4, 5, 6]], 6 },
        { [[5, 5, 5], [1, 1, 1]], 6 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, long expected)
    {
        var actual = MaxRatings(input);
        Assert.Equal(expected, actual);
    }
}

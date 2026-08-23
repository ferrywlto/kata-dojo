public class Q4008_MinInitialStrengthToDefeatAllMonsters
{
    public long MinInitialStrength(int[] monsters, int[][] boosts)
    {
        return 0L;
    }

    public static TheoryData<int[], int[][], long> TestData => new()
    {
        { [5, 10, 15], [[1, 1, 10]], 30 },
        { [5, 10, 15], [[1, 2, 10], [1, 2, 5]], 5 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] monsters, int[][] boosts, long expected)
    {
        var actual = MinInitialStrength(monsters, boosts);
        Assert.Equal(expected, actual);
    }
}

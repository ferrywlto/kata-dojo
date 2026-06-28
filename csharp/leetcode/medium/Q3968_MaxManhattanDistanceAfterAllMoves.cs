public class Q3968_MaxManhattanDistanceAfterAllMoves
{
    public int MaxDistance(string moves)
    {
        return 0;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "L_D_", 4 },
        { "U_R", 3 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MaxDistance(input);
        Assert.Equal(expected, actual);
    }
}

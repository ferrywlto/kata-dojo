public class Q2833_FurthestPointFromOrigin
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"L_RL__R", 3},
        {"_R__LL_", 5},
        {"_______", 7},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = FurthestDistanceFromOrigin(input);
        Assert.Equal(expected, actual);
    }
}
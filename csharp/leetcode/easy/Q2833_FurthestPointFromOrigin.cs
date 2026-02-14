public class Q2833_FurthestPointFromOrigin
{
    // TC: O(n), n scale with length of moves
    // SC: O(1), space used does not scale with input
    public int FurthestDistanceFromOrigin(string moves)
    {
        var left = 0;
        var right = 0;
        var any = 0;
        foreach (var m in moves)
        {
            switch (m)
            {
                case 'L': left++; break;
                case 'R': right++; break;
                default: any++; break;
            }
        }
        return Math.Max(left, right) - Math.Min(left, right) + any;
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

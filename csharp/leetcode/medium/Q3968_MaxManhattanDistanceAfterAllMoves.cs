public class Q3968_MaxManhattanDistanceAfterAllMoves
{
    // TC: O(n), n scales with length of moves
    // SC: O(1)
    public int MaxDistance(string moves)
    {
        // 0 - UP
        // 1 - DOWN
        // 2 - LEFT
        // 3 - RIGHT
        // 4 - _
        Span<int> count = stackalloc int[5];

        foreach (var c in moves)
        {
            switch (c)
            {
                case 'U': count[0]++; break;
                case 'D': count[1]++; break;
                case 'L': count[2]++; break;
                case 'R': count[3]++; break;
                default: count[4]++; break;
            }
        }
        return Math.Abs(count[0] - count[1]) + Math.Abs(count[2] - count[3]) + count[4];
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

public class Q4034_MinBishopMovesToReachTarget
{
    // TC: O(1)
    // SC: O(1)
    public int MinBishopMoves(int[] source, int[] target)
    {
        // only to check 3 cases:
        // 1. Not possible to reach (e.g. on alternate parity row with same parity col, vice versa.
        if ((source[0] % 2 == target[0] % 2 && source[1] % 2 != target[1] % 2) ||
            (source[0] % 2 != target[0] % 2 && source[1] % 2 == target[1] % 2)) return -1;

        // 2. If it can reach by go to four diagonal direction, then answer is 1.
        var row = source[0];
        var col = source[1];
        var step = 1;
        while (step < 8)
        {
            if (row + step == target[0] && col + step == target[1] ||
            row - step == target[0] && col - step == target[1] ||
            row + step == target[0] && col - step == target[1] ||
            row - step == target[0] && col + step == target[1]) return 1;
            step++;
        }

        // 3. Else answer is 2 by observation, Bishop can reach any possible cell with 2 moves.
        return 2;
    }

    public static TheoryData<int[], int[], int> TestData => new()
    {
        { [8, 1], [1, 8], 1 },
        { [4, 2], [1, 3], 2 },
        { [1, 1], [3, 4], -1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] source, int[] target, int expected)
    {
        var actual = MinBishopMoves(source, target);
        Assert.Equal(expected, actual);
    }
}

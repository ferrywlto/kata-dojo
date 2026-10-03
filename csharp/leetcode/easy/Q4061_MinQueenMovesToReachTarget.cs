public class Q4061_MinQueenMovesToReachTarget
{
    // TC: O(1)
    // SC: O(1)
    public int MinQueenMoves(int[] source, int[] target)
    {
        if (source[0] == target[0] && source[1] == target[1])
            return 0;
        else if (
            (source[0] == target[0] || source[1] == target[1]) ||
            (Math.Abs(source[0] - target[0]) == Math.Abs(source[1] - target[1]))
        )
            return 1;
        return 2;
    }

    public static TheoryData<int[], int[], int> TestData => new()
    {
        { [8, 1], [1, 8], 1 },
        { [4, 2], [1, 3], 2 },
        { [1, 1], [1, 1], 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] source, int[] target, int expected)
    {
        var actual = MinQueenMoves(source, target);
        Assert.Equal(expected, actual);
    }
}

public class Q4034_MinBishopMovesToReachTarget
{
    public int MinBishopMoves(int[] source, int[] target) {
        return 0;
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

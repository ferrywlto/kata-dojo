public class Q3996_EvenNumOfKnightMoves
{
    public bool CanReach(int[] start, int[] target)
    {
        return false;
    }

    public static TheoryData<int[], int[], bool> TestData => new()
    {
        { [1, 1], [2, 2], true },
        { [4, 5], [6, 6], false },
        { [1, 1], [1, 1], true },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] start, int[] target, bool expected)
    {
        var actual = CanReach(start, target);
        Assert.Equal(expected, actual);
    }
}

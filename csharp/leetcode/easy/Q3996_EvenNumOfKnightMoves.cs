public class Q3996_EvenNumOfKnightMoves
{
    // TC: O(1)
    // SC: O(1)
    /*
     This is an observation based question.
     Contributed by user Yuvaraj:
     A knight always moves from a square of one color to the opposite color with every move.
     If it starts on a black square, after 1 move it will be on a white square, after 2 moves it will be back on a black square, and so on.
     Thus, after an even number of moves, the knight is on the same color as its starting square, while after an odd number of moves, it is on the opposite color.
     Therefore, the target is reachable only if the start and target squares have the same color.
    */
    public bool CanReach(int[] start, int[] target)
    {
        return
            // same color row
            (start[0] % 2 == target[0] % 2 && start[1] % 2 == target[1] % 2) ||
            // alternate color row must be alternate columns for same color
            (start[0] % 2 != target[0] % 2 && start[1] % 2 != target[1] % 2);
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

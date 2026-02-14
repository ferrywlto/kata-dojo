public class Q2660_DetermineWinnerOfBowlingGame
{
    // TC: O(n), n scale with length of player1 and player2
    // SC: O(1), space used does not scale with input
    public int IsWinner(int[] player1, int[] player2)
    {
        var p1 = CalculateScore(player1);
        var p2 = CalculateScore(player2);
        if (p1 > p2) return 1;
        if (p2 > p1) return 2;
        return 0;
    }
    public int CalculateScore(int[] input)
    {
        var score = 0;
        var doubleQuota = 0;
        foreach (var n in input)
        {
            if (n == 10)
            {
                if (doubleQuota > 0)
                {
                    score += 2 * n;
                }
                else
                {
                    score += n;
                }
                doubleQuota = 2;
            }
            else
            {
                if (doubleQuota > 0)
                {
                    score += 2 * n;
                    doubleQuota--;
                }
                else
                {
                    score += n;
                }
            }
        }
        return score;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {
        {[5,10,3,2], [6,5,7,3], 1},
        {[3,5,7,6], [8,10,10,2], 2},
        {[2,3], [4,1], 0},
        {[1,1,1,10,10,10,10], [10,10,10,10,1,1,1], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = IsWinner(input1, input2);
        Assert.Equal(expected, actual);
    }
}

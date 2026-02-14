public class Q3771_TotalScoreOfDungeonRuns(ITestOutputHelper output)
{
    // Recursion or forward + backward propagation
    // Think of Score(n) = Score(n)
    // Score(n - 1) = Score(n - 1) + Score(n)
    // Score(n - 2) = Score(n - 2) + Score(n - 1) + Score(n)
    public long TotalScore(int hp, int[] damage, int[] requirement)
    {
        var scoreTable = new Dictionary<long, long>();

        var score = 0L;
        // var cumulatedDamage = 0L;
        for (var i = 0; i < damage.Length; i++)
        {
            var hpToScore = damage[i] + requirement[i];

            scoreTable.Add(hpToScore, i + 1);
        }
        return score;
    }
    private long Score(int startIdx, int hp, int[] damage, int[] requirement)
    {
        var score = 0L;
        for (var i = startIdx; i < damage.Length; i++)
        {
            hp -= damage[i];
            if (hp >= requirement[i]) score++;
        }
        output.WriteLine($"score: {score}");
        return score;
    }
    public static TheoryData<int, int[], int[], int> TestData => new()
    {
        {11, [3,6,7], [4,2,5], 3},
        {2, [10000,1], [1,1], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int hp, int[] damage, int[] requirement, int expected)
    {
        var actual = TotalScore(hp, damage, requirement);
        Assert.Equal(expected, actual);
    }

}

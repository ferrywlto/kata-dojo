public class Q3771_TotalScoreOfDungeonRuns(ITestOutputHelper output)
{
    public long TotalScore(int hp, int[] damage, int[] requirement)
    {
        var score = 0L;
        for(var i=0; i<damage.Length; i++)
        {
            score += Score(i, hp, damage, requirement);
        }
        return score;
    }
    private long Score(int startIdx, int hp, int[] damage, int[] requirement)
    {
        var score = 0L;
        for(var i=startIdx; i<damage.Length; i++)
        {
            hp -= damage[i];
            if(hp >= requirement[i]) score++;
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

public class Q3771_TotalScoreOfDungeonRuns
{
    public long TotalScore(int hp, int[] damage, int[] requirement)
    {
        return 0;
    }
    public static TheoryData<int, int[], int[], int> TestData => new()
    {
        {11, [3,6,7], [4,2,5], 3},
        {2, [10000,1], [1,1], 1}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int hp, int[] damage, int[] requirement, int expected)
    {
        var actual = TotalScore(hp, damage, requirement);
        Assert.Equal(expected, actual);
    }

}

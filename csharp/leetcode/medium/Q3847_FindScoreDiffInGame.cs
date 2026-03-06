public class Q3847_FindScoreDiffInGame
{
    public int ScoreDifference(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 2, 3], 0 },
        { [2, 4, 2, 1, 2, 1], 4 },
        { [1], -1 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = ScoreDifference(input);
        Assert.Equal(expected, actual);
    }
}

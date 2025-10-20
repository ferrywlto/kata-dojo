public class Q3683_EarliestTimeToFinishOneTask
{
    public int EarliestTime(int[][] tasks)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData =>
        new()
        {
            {
                new int[][]
                {
                    [1, 6],
                    [2, 3],
                },
                5
            },
            {
                new int[][]
                {
                    [100, 100],
                    [100, 100],
                    [100, 100],
                },
                200
            },
        };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] tasks, int expected)
    {
        var actual = EarliestTime(tasks);
        Assert.Equal(expected, actual);
    }
}

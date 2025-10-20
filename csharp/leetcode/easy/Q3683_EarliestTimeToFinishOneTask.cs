public class Q3683_EarliestTimeToFinishOneTask
{
    // TC: O(n), n scale with length of tasks.
    // SC: O(1), space used does not scale with input.
    public int EarliestTime(int[][] tasks)
    {
        var earliest = int.MaxValue;
        foreach (var task in tasks)
        {
            var start = task[0];
            var end = task[1];
            earliest = Math.Min(earliest, start + end);
        }
        return earliest;
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

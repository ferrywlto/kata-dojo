public class Q3386_ButtonWithLongestPushTime
{
    // TC: O(n), n scale with length of events
    // SC: O(1), space used does not scale with input
    public int ButtonWithLongestTime(int[][] events)
    {
        var maxPressIdx = events[0][0];
        var maxTime = events[0][1];
        for (var i = 1; i < events.Length; i++)
        {
            var timeDiff = events[i][1] - events[i - 1][1];
            if (timeDiff > maxTime)
            {
                maxTime = timeDiff;
                maxPressIdx = events[i][0];
            }
            else if (timeDiff == maxTime && events[i][0] < maxPressIdx)
            {
                maxPressIdx = events[i][0];
            }
        }
        return maxPressIdx;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[1,2],[2,5],[3,9],[1,15]], 1},
        {[[10,5],[1,7]], 10},
        {[[9,4],[19,5],[2,8],[3,11],[2,15]], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = ButtonWithLongestTime(input);
        Assert.Equal(expected, actual);
    }

}
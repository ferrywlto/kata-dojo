public class Q4001_AggregateTwoTimeSeries
{
    // TC: O(n)
    // SC: O(n) for the result, O(1) otherwise
    public IList<IList<int>> AggregateTimeSeries(int[][] series1, int[][] series2)
    {
        int idx1 = 0, idx2 = 0;
        var result = new List<IList<int>>();

        while (idx1 < series1.Length || idx2 < series2.Length)
        {
            if (idx1 == series1.Length)
            {
                result.Add([series2[idx2][0], series2[idx2][1]]);
                idx2++;
            }
            else if (idx2 == series2.Length)
            {
                result.Add([series1[idx1][0], series1[idx1][1]]);
                idx1++;
            }
            // ideal case, time is the same, then add both
            else if (series1[idx1][0] == series2[idx2][0])
            {
                result.Add([series1[idx1][0], series1[idx1][1] + series2[idx2][1]]);
                idx1++;
                idx2++;
            }
            // move the lower first
            else if (series1[idx1][0] < series2[idx2][0])
            {
                // take series1 time and value
                result.Add([series1[idx1][0], series1[idx1][1] + series2[idx2][1]]);
                idx1++;
            }
            // series1 > series2
            else
            {
                result.Add([series2[idx2][0], series2[idx2][1] + series1[idx1][1]]);
                idx2++;
            }
        }

        return result;
    }

    public static TheoryData<int[][], int[][], IList<IList<int>>> TestData => new()
    {
        { [[1, 3], [4, 1]], [[2, 2], [5, 2]], [[1, 5], [2, 3], [4, 3], [5, 2]] },
        { [[1, 5], [3, 1]], [[2, 2]], [[1, 7], [2, 3], [3, 1]] },
        { [[1, 5]], [[1000000000, 2]], [[1, 7], [1000000000, 2]] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] s1, int[][] s2, IList<IList<int>> expected)
    {
        var actual = AggregateTimeSeries(s1, s2);
        Assert.Equal(expected, actual);
    }
}

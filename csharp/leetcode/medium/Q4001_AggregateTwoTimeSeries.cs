public class Q4001_AggregateTwoTimeSeries
{
    public IList<IList<int>> AggregateTimeSeries(int[][] series1, int[][] series2)
    {
        return [];
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

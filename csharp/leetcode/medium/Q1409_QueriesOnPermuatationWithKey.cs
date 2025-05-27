public class Q1409_QueriesOnPermutationWithKey
{
    public int[] ProcessQueries(int[] queries, int m)
    {
        return [];
    }
    public static TheoryData<int[], int, int[]> TestData => new()
    {
        {[3,1,2,1], 5, [2,1,2,1]},
        {[4,1,2,2], 4, [3,1,2,0]},
        {[7,5,5,8,3], 4, [6,5,0,7,5]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int m, int[] expected)
    {
        var actual = ProcessQueries(input, m);
        Assert.Equal(expected, actual);
    }
}
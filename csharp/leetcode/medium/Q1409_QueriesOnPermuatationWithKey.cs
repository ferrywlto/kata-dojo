public class Q1409_QueriesOnPermutationWithKey
{
    // TC: O(n*m), n scale with length of queries
    // SC: O(m)   
    public int[] ProcessQueries(int[] queries, int m)
    {
        var p = new List<int>();
        var p_val = 0;
        for (var i = 0; i < m; i++)
        {
            p.Add(++p_val);
        }

        var result = new int[queries.Length];
        for (var j = 0; j < queries.Length; j++)
        {
            var idx = p.IndexOf(queries[j]);
            result[j] = idx;

            p.RemoveAt(idx);
            p.Insert(0, queries[j]);
        }
        return result;
    }
    public static TheoryData<int[], int, int[]> TestData => new()
    {
        {[3,1,2,1], 5, [2,1,2,1]},
        {[4,1,2,2], 4, [3,1,2,0]},
        {[7,5,5,8,3], 8, [6,5,0,7,5]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int m, int[] expected)
    {
        var actual = ProcessQueries(input, m);
        Assert.Equal(expected, actual);
    }
}
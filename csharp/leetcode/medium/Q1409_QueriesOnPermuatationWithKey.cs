public class Q1409_QueriesOnPermutationWithKey(ITestOutputHelper output)
{
    public int[] ProcessQueries(int[] queries, int m)
    {
        var p = new int[m];
        var result = new int[queries.Length];
        var p_val = 0;
        for(var i=0; i<m; i++)
        {
            p[i] = ++p_val;
        }
        output.WriteLine("init: {0}", string.Join(',', p));
        for(var j=0; j<queries.Length; j++)
        {
            for(var k=0; k<p.Length; k++)
            {
                if(p[k] == queries[j]) {
                    result[j] = k;
                    output.WriteLine("{0} found at {1}", queries[j], k);
                    shiftElementsRight(p, k);
                    break;
                }
            }
        }
        return result;
    }
    private void shiftElementsRight(int[] input, int upToIdx)
    {
        var temp = input[upToIdx];
        for(var i=upToIdx; i>=1; i--)
        {
            input[i] = input[i-1];
        }
        input[0] = temp;
        output.WriteLine(string.Join(',', input));
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
public class Q3796_FindMaxValueInConstrainedSequence
{
    public int FindMaxVal(int n, int[][] restrictions, int[] diff)
    {
        var result = Enumerable.Repeat(long.MaxValue, n).ToArray();
        
        result[0] = 0;
        for(var i=0; i<restrictions.Length; i++)
        {
            result[restrictions[i][0]] = restrictions[i][1];
        }

        for(var i=0; i<diff.Length; i++)
        {   
            result[i+1] = Math.Min(result[i+1], result[i] + diff[i]);
        }

        var answer = result[^1];
        for(var i=result.Length - 2; i>=0; i--)
        {
            // Missing this backward propagation
            result[i] = Math.Min(result[i], result[i+1] + diff[i]);
            answer = Math.Max(answer, result[i]);
        }

        return (int)answer;
    }
    public static TheoryData<int, int[][], int[], int> TestData => new()
    {
        {10, [[3,1],[8,1]], [2,2,3,1,4,5,1,1,2], 6},
        {8, [[3,2]], [3,5,2,4,2,3,1], 12},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] restrictions, int[] diff, int expected)
    {
        var actual = FindMaxVal(n, restrictions, diff);
        Assert.Equal(expected, actual);
    }
}

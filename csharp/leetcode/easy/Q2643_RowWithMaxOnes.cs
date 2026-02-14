public class Q2643_RowWithMaxOnes
{
    // TC: O(n * m), scale with rows times columns in mat, equals to total elements in mat
    // SC: O(1), space used does not scale with input
    public int[] RowAndMaximumOnes(int[][] mat)
    {
        var result = new int[2];
        for (var i = 0; i < mat.Length; i++)
        {
            var oneCount = 0;
            for (var j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 1) oneCount++;
            }
            if (oneCount > result[1])
            {
                result[0] = i;
                result[1] = oneCount;
            }
        }
        return result;
    }
    public static TheoryData<int[][], int[]> TestData => new()
    {
        {new int[][] {[0,1],[1,0]}, new int[] {0,1}},
        {new int[][] {[0,0,0],[0,1,1]}, new int[] {1,2}},
        {new int[][] {[0,0],[1,1],[0,0]}, new int[] {1,2}},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[] expected)
    {
        var actual = RowAndMaximumOnes(input);
        Assert.Equal(expected, actual);
    }
}

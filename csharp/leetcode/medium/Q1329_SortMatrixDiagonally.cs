public class Q1329_SortMatrixDiagonally
{
    // TC: O(n ^ 2)
    // SC: O(1)
    public int[][] DiagonalSort(int[][] mat)
    {
        var col = 0;
        int row;
        for(row=0; row<mat.Length; row++)
        {
            SortDiagonal(mat, row, col);
        }
        row = 0;
        for(col=1; col<mat[0].Length; col++)
        {
            SortDiagonal(mat, row, col);
        }
        return mat;
    }
    // TC: O(r or c => n)
    // SC: O(n)
    // Sort inplace
    private void SortDiagonal(int[][] input, int row, int col)
    {
        var list = new List<int>();
        int r = row, c = col;
        while(r < input.Length && c < input[0].Length) {
            list.Add(input[r++][c++]);
        }
        list.Sort();

        var listIdx = 0;
        r = row;
        c = col;
        while(r < input.Length && c < input[0].Length) {
            input[r++][c++] = list[listIdx++];
        }
    }
    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {[[3,3,1,1],[2,2,1,2],[1,1,1,2]], [[1,1,1,1],[1,2,2,2],[1,2,3,3]]},
        {[[11,25,66,1,69,7],[23,55,17,45,15,52],[75,31,36,44,58,8],[22,27,33,25,68,4],[84,28,14,11,5,50]], [[5,17,4,1,52,7],[11,11,25,45,8,69],[14,23,25,44,58,15],[22,27,31,36,50,66],[84,28,75,33,55,68]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = DiagonalSort(input);
        Assert.Equal(expected, actual);
    }
}
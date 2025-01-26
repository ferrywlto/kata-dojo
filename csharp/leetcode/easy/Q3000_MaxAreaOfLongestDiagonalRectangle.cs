public class Q3000_MaxAreaOfLongestDiagonalRectangle
{
    // TC: O(n), n scale with length of dimensions.  
    // SC: O(1), space used does not scale with input
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        double longestDiag = -1;
        int largestArea = -1;
        for (var i = 0; i < dimensions.Length; i++)
        {
            var d = dimensions[i];
            double diag = Math.Sqrt(d[0] * d[0] + d[1] * d[1]);

            if (diag > longestDiag)
            {
                largestArea = d[0] * d[1];
                longestDiag = diag;
            }
            else if (diag == longestDiag)
            {
                longestDiag = diag;

                var area = d[0] * d[1];
                if (area > largestArea)
                {
                    largestArea = area;
                }
            }
        }
        return largestArea;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[9,3],[8,6]], 48},
        {[[3,4],[4,3]], 12},
        {[[6,5],[8,6],[2,10],[8,1],[9,2],[3,5],[3,5]], 20},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = AreaOfMaxDiagonal(input);
        Assert.Equal(expected, actual);
    }
}
class Q1351_CountNegativeNumbersInSortedMatrix
{
    // TC: O(n), n = total elements in grid worst case (all negative)
    // SC: O(1), no space used for operation
    public int CountNegatives(int[][] grid)
    {
        var count = 0;
        for(var i=grid.Length-1; i>=0; i--)
        {
            for(var j=grid[i].Length-1; j>=0; j--)
            {
                if (grid[i][j] >= 0) break;
                count++;
            }
        }
        return count;
    }
    public int CountNegatives_EarlyTermination(int[][] grid)
    {
        // start from top-right corner, consider it is sorted decreasingly columnwise also.
        var count = 0;
        int i = 0;
        int j = grid[0].Length - 1;
        while (i < grid.Length && j >=0)
        {
            if (grid[i][j] < 0)
            {
                count += grid.Length - i;
                j--;
            }
            else i++;
        }        
        return count;
    }    
}
class Q1351_CountNegativeNumbersInSortedMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [4,3,2,-1],
                [3,2,1,-1],
                [1,1,-1,-2],
                [-1,-1,-2,-3],
            }, 8
        ],
        [new int[][]{[3,2],[1,0]}, 0]
    ];
}
public class Q1351_CountNegativeNumbersInSortedMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1351_CountNegativeNumbersInSortedMatrixTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1351_CountNegativeNumbersInSortedMatrix();
        var actual = sut.CountNegatives_EarlyTermination(input);
        Assert.Equal(expected, actual);
    }
}
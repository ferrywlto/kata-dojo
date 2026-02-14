class Q892_SurfaceAreaOf3DShape
{
    // TC: O(n), n is total cells in grid, all iterate only once
    // SC: O(1), no data stucture used for the solution
    public int SurfaceArea(int[][] grid)
    {
        // input must be n x n matrix
        int matrixSize = grid.Length;
        var surfaceArea = 0;

        for (var row = 0; row < matrixSize; row++)
        {
            for (var col = 0; col < matrixSize; col++)
            {
                if (grid[row][col] == 0) continue;
                var facesExposed = CalcTowerExposedFaces(grid[row][col]);

                // case north
                if (row > 0)
                {
                    facesExposed -= grid[row - 1][col] >= grid[row][col]
                        ? grid[row][col]
                        : grid[row - 1][col];
                }
                // case south
                if (row < matrixSize - 1)
                {
                    facesExposed -= grid[row + 1][col] >= grid[row][col]
                        ? grid[row][col]
                        : grid[row + 1][col];
                }
                // case left
                if (col > 0)
                {
                    facesExposed -= grid[row][col - 1] >= grid[row][col]
                        ? grid[row][col]
                        : grid[row][col - 1];
                }
                if (col < matrixSize - 1)
                {
                    facesExposed -= grid[row][col + 1] >= grid[row][col]
                        ? grid[row][col]
                        : grid[row][col + 1];
                }
                surfaceArea += facesExposed;
            }
        }
        return surfaceArea;
    }

    // 1 cube has 6 faces
    public int CalcTowerExposedFaces(int height) => height * 4 + 2;
}

class Q892_SurfaceAreaOf3DShapeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][]{[1,2],[3,4]}, 34],
        [new int[][]{[1,1,1],[1,0,1],[1,1,1]}, 32],
        [new int[][]{[2,2,2],[2,1,2],[2,2,2]}, 46],
    ];
}

public class Q892_SurfaceAreaOf3DShapeTests
{
    [Theory]
    [ClassData(typeof(Q892_SurfaceAreaOf3DShapeTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q892_SurfaceAreaOf3DShape();
        var actual = sut.SurfaceArea(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 6)]
    [InlineData(2, 10)]
    [InlineData(3, 14)]
    [InlineData(4, 18)]
    public void CalcTowerExposedFaces_InputHeight_ReturnCorrectExposedFaces(int input, int expected)
    {
        var sut = new Q892_SurfaceAreaOf3DShape();
        var actual = sut.CalcTowerExposedFaces(input);
        Assert.Equal(expected, actual);
    }
}

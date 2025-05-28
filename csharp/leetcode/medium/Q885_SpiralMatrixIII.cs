public class Q885_SpiralMatrixIII(ITestOutputHelper output)
{
    // TC: O(n), n scale with rows * cols
    // SC: O(n), the result list must equals to rows * cols
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        // var step = 0;
        // steps: 0, 1, 2, 3, 4, 5, 6, 7, 
        // dis:   1, 1, 2, 2, 3, 3, 4, 4
        var totalSteps = rows * cols;

        var result = new List<int[]>
        {
            ([rStart, cStart])
        };

        var directionCount = 0;
        while (result.Count < totalSteps)
        {
            var direction = directionCount % 4;
            var distance = (directionCount / 2) + 1;

            if (direction == 0)
            {
                // output.WriteLine($"right, d:{distance}");
                for (var i = 0; i < distance; i++)
                {
                    cStart++;
                    // output.WriteLine($"[{rStart},{cStart}]");
                    if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                    {
                        // output.WriteLine($"add [{rStart},{cStart}]");
                        result.Add([rStart, cStart]);
                    }
                    // step++;
                }
            }
            else if (direction == 1)
            {
                // output.WriteLine($"down, d:{distance}");
                for (var i = 0; i < distance; i++)
                {
                    rStart++;
                    // output.WriteLine($"[{rStart},{cStart}]");
                    if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                    {
                        // output.WriteLine($"add [{rStart},{cStart}], rows: {rows}");
                        result.Add([rStart, cStart]);
                    }
                    // step++;
                }
            }
            else if (direction == 2)
            {
                // output.WriteLine($"left, d:{distance}");
                for (var i = 0; i < distance; i++)
                {
                    cStart--;
                    // output.WriteLine($"[{rStart},{cStart}]");
                    if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                    {
                        // output.WriteLine($"add [{rStart},{cStart}]");
                        result.Add([rStart, cStart]);
                    }
                    // step++;
                }
            }
            else
            {
                output.WriteLine($"up, d:{distance}");
                for (var i = 0; i < distance; i++)
                {
                    rStart--;
                    // output.WriteLine($"[{rStart},{cStart}]");
                    if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                    {
                        // output.WriteLine($"add [{rStart},{cStart}]");
                        result.Add([rStart, cStart]);
                    }
                    // step++;
                }
            }
            directionCount++;
        }
        return result.ToArray();
    }
    public static TheoryData<int, int, int, int, int[][]> TestData => new()
    {
        {1,4,0,0, [[0,0],[0,1],[0,2],[0,3]]},
        {5,6,1,4, [[1,4],[1,5],[2,5],[2,4],[2,3],[1,3],[0,3],[0,4],[0,5],[3,5],[3,4],[3,3],[3,2],[2,2],[1,2],[0,2],[4,5],[4,4],[4,3],[4,2],[4,1],[3,1],[2,1],[1,1],[0,1],[4,0],[3,0],[2,0],[1,0],[0,0]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int row, int col, int rStart, int cStart, int[][] expected)
    {
        var actual = SpiralMatrixIII(row, col, rStart, cStart);
        Assert.Equal(expected, actual);
    }
}
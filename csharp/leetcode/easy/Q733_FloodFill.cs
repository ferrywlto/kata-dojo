namespace dojo.leetcode;

public class Q733_FloodFill
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) 
    {
        var queue = new Queue<(int row, int col)>();
        var sourceColor = image[sr][sc];

        AddIfCellValid(sr, sc, sourceColor);

        while(queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            image[r][c] = color;

            AddIfCellValid(r - 1, c, sourceColor);
            AddIfCellValid(r + 1, c, sourceColor);
            AddIfCellValid(r, c - 1, sourceColor);
            AddIfCellValid(r, c + 1, sourceColor);
        }

        void AddIfCellValid(int row, int col, int color) 
        {
            if (row >= 0 && row < image.Length &&
                col >= 0 && col < image[0].Length &&
                image[row][col] == color)
            {
                queue.Enqueue((row, col));
            }
        }

        return image;   
    }    
}

public class Q733_FloodFillTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new int[][]
            {
                [1,1,1],
                [1,1,0],
                [1,0,1]
            },
            1, 1, 2,
            new int[][]
            {
                [2,2,2],
                [2,2,0],
                [2,0,1],
            }
        ],
        [
            new int[][]
            {
                [0,0,0],
                [0,0,0],
            },
            0, 0, 0,
            new int[][]
            {
                [0,0,0],
                [0,0,0],
            }
        ]
    ];
}

public class Q733_FloodFillTests
{
    [Theory]
    [ClassData(typeof(Q733_FloodFillTestData))]
    public void OfficialTestCases(int[][] input, int row, int col, int color, int[][] expected)
    {
        var sut = new Q733_FloodFill();
        var actual = sut.FloodFill(input, row, col, color);
        Assert.Equal(expected, actual);
    }
}
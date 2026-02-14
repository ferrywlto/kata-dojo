public class Q1861_RotatingTheBox
{
    public char[][] RotateTheBox(char[][] boxGrid)
    {
        foreach (var row in boxGrid)
        {
            MoveStone(row);
        }
        return Transpose(boxGrid);
    }

    private char[][] Transpose(char[][] boxGrid)
    {
        var n = boxGrid.Length;
        var m = boxGrid[0].Length;
        var result = new char[m][];
        for (var j = 0; j < m; j++)
        {
            result[j] = new char[n];
            for (var i = 0; i < n; i++)
            {
                result[j][n - 1 - i] = boxGrid[i][j];
            }
        }
        return result;
    }

    private void Backfill(char[] row, int stoneCount, int wallIdx)
    {
        var idx = wallIdx - 1;
        while (stoneCount > 0 && idx >= 0)
        {
            row[idx] = '#';
            stoneCount--;
            idx--;
        }
    }
    private void MoveStone(char[] row)
    {
        var stoneCount = 0;
        for (var i = 0; i < row.Length; i++)
        {
            if (row[i] == '*')
            {
                Backfill(row, stoneCount, i);
                stoneCount = 0;
            }
            else if (row[i] == '#')
            {
                row[i] = '.';
                stoneCount++;
            }
        }
        Backfill(row, stoneCount, row.Length);
    }
    public static TheoryData<char[][], char[][]> TestData => new()
    {
        {
            new char[][]
            {
                ['#','.','#'],
            },
            new char[][]
            {
                ['.'],
                ['#'],
                ['#']
            }
        },
        {
            new char[][]
            {
                ['#','.','*','.'],
                ['#','#','*','.'],
            },
            new char[][]
            {
                ['#','.'],
                ['#','#'],
                ['*','*'],
                ['.','.'],
            }
        },
        {
            new char[][]
            {
                ['#','#','*','.','*','.'],
                ['#','#','#','*','.','.'],
                ['#','#','#','.','#','.']
            },
            new char[][]
            {
                ['.','#','#'],
                ['.','#','#'],
                ['#','#','*'],
                ['#','*','.'],
                ['#','.','*'],
                ['#','.','.']
            }
        }
    };


    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(char[][] boxGrid, char[][] expected)
    {
        var result = RotateTheBox(boxGrid);
        Assert.Equal(expected, result);
    }
}

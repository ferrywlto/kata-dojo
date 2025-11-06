public class Q1861_RotatingTheBox
{
    public char[][] RotateTheBox(char[][] boxGrid)
    {
        foreach (var row in boxGrid)
        {
            MoveLastStoneInRowToBottom(row);
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
    // Use an easier approach first. Greedy move
    private void MoveStone(char[] row, int startIdx)
    {
        var targetIdx = -1;
        for (var i = startIdx; i < row.Length; i++)
        {
            if (row[i] == '.')
            {
                targetIdx = i;
            }
            else break;
        }
        if (targetIdx != -1)
        {
            row[targetIdx] = '#';
            row[startIdx - 1] = '.';
        }
    }
    private void MoveLastStoneInRowToBottom(char[] row)
    {
        for (var i = row.Length - 2; i >= 0; i--)
        {
            if (row[i] == '#')
            {
                MoveStone(row, i + 1);
            }
        }
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

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
    // Use an easier approach first. Greedy move
    // Now use two pointers
    private void MoveStone(char[] row)
    {
        var left = row.Length - 1;
        var right = row.Length - 1;
        while (right >= 0 && left >= 0)
        {
            if (row[left] == '#' && row[right] == '.' && left < right)
            {
                // Move stone
                row[right] = '#';
                row[left] = '.';

                left--;
                right--;
            }
            else if (row[left] == '*')
            {
                // Obstacle
                right = left - 1;
                left--;
            }
            else if (row[left] == '#' && row[right] == '#')
            {
                left--;
                right--;
            }
            else
            {
                left--;
            }
        }
    }
    private void MoveLastStoneInRowToBottom(char[] row)
    {
        for (var i = row.Length - 2; i >= 0; i--)
        {
            if (row[i] == '#')
            {
                MoveStone(row);
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

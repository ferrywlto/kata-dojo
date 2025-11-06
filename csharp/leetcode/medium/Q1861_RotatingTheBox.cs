using Xunit;

public class Q1861_RotatingTheBox
{
    public char[][] RotateTheBox(char[][] boxGrid)
    {
        return boxGrid;
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

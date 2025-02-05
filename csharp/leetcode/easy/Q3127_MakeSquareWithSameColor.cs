public class Q3127_MakeSquareWithSameColor
{
    public bool CanMakeSquare(char[][] grid)
    {
        return false;
    }
    public static TheoryData<char[][], bool> TestData => new()
    {
        {
            [['B','W','B'],['B','W','W'],['B','W','B']], true
        },
        {
            [['B','W','B'],['W','B','W'],['B','W','B']], false
        },
        {
            [['B','W','B'],['B','W','W'],['B','W','W']], true
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(char[][] input, bool expected)
    {
        var actual = CanMakeSquare(input);
        Assert.Equal(expected, actual);
    }
}
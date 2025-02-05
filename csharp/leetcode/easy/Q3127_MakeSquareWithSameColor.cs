public class Q3127_MakeSquareWithSameColor
{
    // TC: O(1), because the input is always 3x3, and we only need to iterate 4 times
    // SC: O(1), the dictionary is always has two entries only
    public bool CanMakeSquare(char[][] grid)
    {
        var dict = new Dictionary<char, int>{
            {'B', 0},
            {'W', 0}
        };

        for (var row = 0; row < 2; row++)
        {
            for (var col = 0; col < 2; col++)
            {
                dict[grid[row][col]]++;
                dict[grid[row + 1][col]]++;
                dict[grid[row][col + 1]]++;
                dict[grid[row + 1][col + 1]]++;

                if (
                    (dict['B'] == 4 && dict['W'] == 0) ||
                    (dict['W'] == 4 && dict['B'] == 0) ||
                    (dict['B'] == 3 && dict['W'] == 1) ||
                    (dict['W'] == 3 && dict['B'] == 1)
                ) return true;
                dict['B'] = 0;
                dict['W'] = 0;
            }
        }
        return false;
    }
    
    public static TheoryData<char[][], bool> TestData => new()
    {
        {[['B','W','B'],['B','W','W'],['B','W','B']], true},
        {[['B','W','B'],['W','B','W'],['B','W','B']], false},
        {[['B','W','B'],['B','W','W'],['B','W','W']], true},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(char[][] input, bool expected)
    {
        var actual = CanMakeSquare(input);
        Assert.Equal(expected, actual);
    }
}
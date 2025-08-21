public class Q1277_CountSquareSubmatricesWithAllOnes
{
    public int CountSquares(int[][] matrix)
    {
        return 0;
    }
    
    public static TheoryData<int[][], int> TestData => new()
    {
        {
            [
                [0, 1, 1, 1],
                [1, 1, 1, 1],
                [0, 1, 1, 1]
            ],
            15
        },
        {
            [
                [1, 0, 1],
                [1, 1, 1],
                [1, 0, 1]
            ],
            7
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] matrix, int expected)
    {
        var result = CountSquares(matrix);
        Assert.Equal(expected, result);
    }
}

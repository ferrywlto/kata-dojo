public class Q2319_CheckIfMatrixIsXMatrix
{
    public bool CheckXMatrix(int[][] grid)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [2,0,0,1],
                [0,3,1,0],
                [0,5,2,0],
                [4,0,0,2],
            }, true
        ],
        [
            new int[][]
            {
                [5,7,0],
                [0,3,1],
                [0,5,0],
            }, false
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, bool expected)
    {
        var actual = CheckXMatrix(input);
        Assert.Equal(expected, actual);
    }
}

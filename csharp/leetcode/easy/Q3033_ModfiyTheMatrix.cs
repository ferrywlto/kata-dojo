public class Q3033_ModfiyTheMatrix
{
    public int[][] ModifiedMatrix(int[][] matrix)
    {
        return [];
    }
    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {
            [
                [1,2,-1],
                [4,-1,6],
                [7,8,9]
            ],
            [
                [1,2,9],
                [4,8,6],
                [7,8,9]
            ]
        },
        {
            [
                [3,-1],
                [5,2]
            ],
            [
                [3,2],
                [5,2]
            ]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = ModifiedMatrix(input);
        Assert.Equal(expected, actual);
    }
}
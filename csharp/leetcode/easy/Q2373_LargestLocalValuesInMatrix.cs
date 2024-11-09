public class Q2373_LargestLocalValuesInMatrix
{
    public int[][] LargestLocal(int[][] grid)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [9,9,8,1],
                [5,6,2,6],
                [8,2,6,4],
                [6,2,2,2],
            },
            new int[][]
            {
                [9,9],
                [8,6],
            }
        ],
        [
            new int[][]
            {
                [1,1,1,1,1],
                [1,1,1,1,1],
                [1,1,2,1,1],
                [1,1,1,1,1],
                [1,1,1,1,1],
            },
            new int[][]
            {
                [2,2,2],
                [2,2,2],
                [2,2,2],
            },
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = LargestLocal(input);
        Assert.Equal(expected, actual);
    }
}
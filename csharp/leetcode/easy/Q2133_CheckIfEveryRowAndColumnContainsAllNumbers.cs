public class Q2133_CheckIfEveryRowAndColumnContainsAllNumbers
{
    public bool CheckValid(int[][] matrix)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [1,2,3],[3,1,2],[2,3,1]
            }, true,
        ],
        [
            new int[][]
            {
                [1,1,1],[1,2,3],[1,2,3]
            }, false,
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, bool expected)
    {
        var actual = CheckValid(input);
        Assert.Equal(expected, actual);
    }
}
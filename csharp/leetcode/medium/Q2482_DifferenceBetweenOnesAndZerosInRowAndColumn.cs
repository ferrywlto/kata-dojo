public class Q2482_DifferenceBetweenOnesAndZerosInRowAndColumn
{
    public int[][] OnesMinusZeros(int[][] grid)
    {
        return [];
    }
    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {
            [
                [0,1,1],
                [1,0,1],
                [0,0,1]
            ],
            [
                [0,0,4],
                [0,0,4],
                [-2,-2,2]
            ]
        },
        {
            [
                [1,1,1],
                [1,1,1]
            ],
            [
                [5,5,5],
                [5,5,5]
            ]
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = OnesMinusZeros(input);
        Assert.Equal(expected, actual);
    }
}
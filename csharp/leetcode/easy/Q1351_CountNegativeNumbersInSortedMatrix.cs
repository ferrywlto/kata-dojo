class Q1351_CountNegativeNumbersInSortedMatrix
{
    public int CountNegatives(int[][] grid)
    {
        return 0;
    }
}
class Q1351_CountNegativeNumbersInSortedMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [4,3,2,-1],
                [3,2,1,-1],
                [1,1,-1,-2],
                [-1,-1,-2,-3],
            }, 8
        ],
        [new int[][]{[3,2],[1,0]}, 0]
    ];
}
public class Q1351_CountNegativeNumbersInSortedMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1351_CountNegativeNumbersInSortedMatrixTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1351_CountNegativeNumbersInSortedMatrix();
        var actual = sut.CountNegatives(input);
        Assert.Equal(expected, actual);
    }
}
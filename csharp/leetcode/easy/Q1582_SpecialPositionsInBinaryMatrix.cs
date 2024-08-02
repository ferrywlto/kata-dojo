class Q1582_SpecialPositionsInBinaryMatrix
{
    public int NumSpecial(int[][] mat)
    {
        return 0;
    }
}
class Q1582_SpecialPositionsInBinaryMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [1,0,0],
                [0,0,1],
                [1,0,0]
            }, 1
        ],
        [
            new int[][]
            {
                [1,0,0],
                [0,1,0],
                [0,0,1]
            }, 3
        ]
    ];
}
public class Q1582_SpecialPositionsInBinaryMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1582_SpecialPositionsInBinaryMatrixTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1582_SpecialPositionsInBinaryMatrix();
        var actual = sut.NumSpecial(input);
        Assert.Equal(expected, actual);
    }
}
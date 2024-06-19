class Q1232_CheckIfStraightLine
{
    public bool CheckStraightLine(int[][] coordinates)
    {
        return false;
    }
}
class Q1232_CheckIfStraightLineTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] { [1, 2], [2, 3], [3, 4], [4, 5], [5, 6], [6, 7] }, true],
        [new int[][] { [1, 1], [2, 2], [3, 4], [4, 5], [5, 6], [7, 7] }, false],
    ];
}
public class Q1232_CheckIfStraightLineTests
{
    [Theory]
    [ClassData(typeof(Q1232_CheckIfStraightLineTestData))]
    public void OfficialTestCases(int[][] input, bool expected)
    {
        var sut = new Q1232_CheckIfStraightLine();
        var actual = sut.CheckStraightLine(input);
        Assert.Equal(expected, actual);
    }
}
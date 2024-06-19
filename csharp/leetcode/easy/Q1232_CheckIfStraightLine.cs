class Q1232_CheckIfStraightLine
{
    // TC: O(n), need to iterate the length of input to calculate the slopes
    // SC: O(1), space not scale with length of input
    public bool CheckStraightLine(int[][] coordinates)
    {
        // coordinates must have at least 2 elements
        if (coordinates.Length < 2) return false;
        double? slope = null;
        for(var i=0; i<coordinates.Length-1; i++)
        {
            if (coordinates[i][0] == coordinates[i + 1][0]
            && coordinates[i][1] == coordinates[i + 1][1]) continue;
            double yDiff = coordinates[i + 1][1] - coordinates[i][1];
            double xDiff = coordinates[i + 1][0] - coordinates[i][0];
            var s = xDiff != 0 ? yDiff / xDiff : int.MaxValue;

            if (slope == null) slope = s;
            else if (slope != s) return false;
        }

        return true;
    }
}
class Q1232_CheckIfStraightLineTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] { [1, 2], [2, 3], [3, 4], [4, 5], [5, 6], [6, 7] }, true],
        [new int[][] { [1, 1], [2, 2], [3, 4], [4, 5], [5, 6], [7, 7] }, false],
        [new int[][] { [-4, -3], [1, 0], [3, -1], [0, -1], [-5, 2] }, false],
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
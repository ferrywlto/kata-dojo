class Q657_RobotReturnToOrigin
{
    // TC: O(n)
    // SC: O(1)
    public bool JudgeCircle(string moves)
    {
        var x = 0;
        var y = 0;
        for (var i = 0; i < moves.Length; i++)
        {
            switch (moves[i])
            {
                case 'U': y++; break;
                case 'D': y--; break;
                case 'R': x++; break;
                case 'L': x--; break;
                default: break;
            }
        }
        return x == 0 && y == 0;
    }
}

class Q657_RobotReturnToOriginTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["UD", true],
        ["LL", false],
    ];
}

public class Q657_RobotReturnToOriginTests
{
    [Theory]
    [ClassData(typeof(Q657_RobotReturnToOriginTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q657_RobotReturnToOrigin();
        var actual = sut.JudgeCircle(input);
        Assert.Equal(expected, actual);
    }
}

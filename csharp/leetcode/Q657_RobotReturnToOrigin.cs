namespace dojo.leetcode;

public class Q657_RobotReturnToOrigin
{
    public bool JudgeCircle(string moves) 
    {
        return false;    
    }
}

public class Q657_RobotReturnToOriginTestData : TestData
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
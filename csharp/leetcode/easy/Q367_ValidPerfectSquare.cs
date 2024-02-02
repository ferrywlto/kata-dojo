
namespace dojo.leetcode;

public class Q367_ValidPerfectSquare
{
    public bool IsPerfectSquare(int num)
    {
        return false;
    }
}

public class Q367_ValidPerfectSquareTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [16, true],       
        [14, false],       
    ];
}

public class Q367_ValidPerfectSquareTests
{
    [Theory]
    [ClassData(typeof(Q367_ValidPerfectSquareTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q367_ValidPerfectSquare();
        var actual = sut.IsPerfectSquare(input);
        Assert.Equal(expected, actual);
    }
}
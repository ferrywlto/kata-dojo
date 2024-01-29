
namespace dojo.leetcode;

public class Q342_PowerOfFour
{
    public bool IsPowerOfFour(int n)
    {
        return false;
    }
}

public class Q342_PowerOfFourTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [16, true],
        [5, false],
        [1, true],
    ];
}

public class Q342_PowerOfFourTests: BaseTest
{
    [Theory]
    [ClassData(typeof(Q342_PowerOfFourTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q342_PowerOfFour();
        var actual = sut.IsPowerOfFour(input);
        Assert.Equal(expected, actual);
    }
}
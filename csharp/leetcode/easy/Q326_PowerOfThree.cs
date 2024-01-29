
namespace dojo.leetcode;

public class Q326_PowerOfThree
{
    public bool IsPowerOfThree(int n)
    {
        return false;
    }
}

public class Q326_PowerOfThreeTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [27, true],
        [0, false],
        [-1, false],
    ];
}

public class Q326_PowerOfThreeTests: BaseTest
{
    [Theory]
    [ClassData(typeof(Q326_PowerOfThreeTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q326_PowerOfThree();
        var actual = sut.IsPowerOfThree(input);
        Assert.Equal(expected, actual);
    }
}
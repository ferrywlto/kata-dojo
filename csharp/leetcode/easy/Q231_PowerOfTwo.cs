namespace dojo.leetcode;

public class Q231_PowerOfTwo
{
    public bool IsPowerOfTwo(int n) 
    {
        return false;
    }
}

public class Q231_PowerOfTwoTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [1, true],
        [16, true],
        [3, false],
    ];
}

public class Q231_PowerOfTwoTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q231_PowerOfTwoTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q231_PowerOfTwo();
        var actual = sut.IsPowerOfTwo(input);
        Assert.Equal(expected, actual);
    }
}
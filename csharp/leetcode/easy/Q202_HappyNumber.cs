namespace dojo.leetcode;

public class Q202_HappyNumbers
{
    public bool IsHappy(int n)
    {
        return false;
    }
}

public class Q202_HappyNumbersTestData: TestData
{
    protected override List<object[]> Data =>
    [
        [19, true],
        [2, false],
    ];
}

public class Q202_HappyNumbersTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q202_HappyNumbersTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q202_HappyNumbers();
        var actual = sut.IsHappy(input);

        Assert.Equal(expected, actual);
    }
}

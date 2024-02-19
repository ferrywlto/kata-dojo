namespace dojo.leetcode;

public class Q520_DetectCaptial
{
    public bool DetectCapitalUse(string word)
    {
        return false;
    }
}

public class Q520_DetectCaptialTestData: TestData
{
    protected override List<object[]> Data =>
    [
        ["USA", true],
        ["leetcode", true],
        ["Google", true],
        ["FlaG", false],
    ];
}

public class Q520_DetectCaptialTests
{
    [Theory]
    [ClassData(typeof(Q520_DetectCaptialTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q520_DetectCaptial();
        var actual = sut.DetectCapitalUse(input);
        Assert.Equal(expected, actual);
    }
}
namespace dojo.leetcode;

public class Q405_ConvertNumToHex
{
    public string ToHex(int num)
    {
        return string.Empty;
    }
}

public class Q405_ConvertNumToHexTestData : TestData
{
    protected override List<object[]> Data =>
        new()
        {
            new object[] {26, "1a"},
            new object[] {-1, "ffffffff"},
            new object[] {0, "0"},
        };
}

public class Q405_ConvertNumToHexTests
{
    [Theory]
    [ClassData(typeof(Q405_ConvertNumToHexTestData))]
    public void OfficialTestCases(int input, string expected)
    {
        var sut = new Q405_ConvertNumToHex();
        var actual = sut.ToHex(input);
        Assert.Equal(expected, actual);
    }
}
class Q1945_SumOfDigitsOfStringAfterConvert
{
    public int GetLucky(string s, int k)
    {
        return 0;
    }
}
class Q1945_SumOfDigitsOfStringAfterConvertTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["iiii", 1, 36],
        ["leetcode", 2, 6],
        ["zbax", 2, 8],
    ];
}
public class Q1945_SumOfDigitsOfStringAfterConvertTests
{
    [Theory]
    [ClassData(typeof(Q1945_SumOfDigitsOfStringAfterConvertTestData))]
    public void OfficialTestCases(string input, int k, int expected)
    {
        var sut = new Q1945_SumOfDigitsOfStringAfterConvert();
        var actual = sut.GetLucky(input, k);
        Assert.Equal(expected, actual);
    }
}
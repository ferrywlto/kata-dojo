class Q1903_LargestOddNumberInString
{
    public string LargestOddNumber(string num)
    {
        return string.Empty;
    }
}
class Q1903_LargestOddNumberInStringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["52", "5"],
        ["4206", ""],
        ["35427", "35427"],
    ];
}
public class Q1903_LargestOddNumberInStringTests
{
    [Theory]
    [ClassData(typeof(Q1903_LargestOddNumberInStringTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1903_LargestOddNumberInString();
        var actual = sut.LargestOddNumber(input);
        Assert.Equal(expected, actual);
    }
}

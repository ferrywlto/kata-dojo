class Q1556_ThousandSeparator
{
    public string ThousandSeparator(int n)
    {
        return string.Empty;
    }
}
class Q1556_ThousandSeparatorTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [987, "987"],
        [1234, "1.234"],
    ];
}
public class Q1556_ThousandSeparatorTests
{
    [Theory]
    [ClassData(typeof(Q1556_ThousandSeparatorTestData))]
    public void OfficialTestCases(int input, string expected)
    {
        var sut = new Q1556_ThousandSeparator();
        var actual = sut.ThousandSeparator(input);
        Assert.Equal(expected, actual);
    }
}
class Q1796_SecondLargestDigitInString
{
    public int SecondHighest(string s)
    {
        return 0;
    }
}
class Q1796_SecondLargestDigitInStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["dfa12321afd", 2],
        ["abc1111", -1],
    ];
}
public class Q1796_SecondLargestDigitInStringTests
{
    [Theory]
    [ClassData(typeof(Q1796_SecondLargestDigitInStringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1796_SecondLargestDigitInString();
        var actual = sut.SecondHighest(input);
        Assert.Equal(expected, actual);
    }
}
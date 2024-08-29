class Q1736_LatestTimeByReplacingHiddenDigits
{
    public string MaximumTime(string time)
    {
        return "";
    }
}
class Q1736_LatestTimeByReplacingHiddenDigitsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["2?:?0", "23:50"],
        ["0?:3?", "09:39"],
        ["1?:22", "19:22"],
    ];
}
public class Q1736_LatestTimeByReplacingHiddenDigitsTests
{
    [Theory]
    [ClassData(typeof(Q1736_LatestTimeByReplacingHiddenDigitsTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1736_LatestTimeByReplacingHiddenDigits();
        var actual = sut.MaximumTime(input);
        Assert.Equal(expected, actual);
    }
}
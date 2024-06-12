class Q1154_DayOfTheYear
{
    // TC: O(1)
    // SC: O(1)
    public int DayOfYear(string date)
    {
        var dateObj = DateOnly.ParseExact(date, "yyyy-MM-dd");
        return dateObj.DayOfYear;
    }
}
class Q1154_DayOfTheYearTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["2019-01-09", 9],
        ["2019-02-10", 41],
    ];
}
public class Q1154_DayOfTheYearTests
{
    [Theory]
    [ClassData(typeof(Q1154_DayOfTheYearTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1154_DayOfTheYear();
        var actual = sut.DayOfYear(input);
        Assert.Equal(expected, actual);
    }
}
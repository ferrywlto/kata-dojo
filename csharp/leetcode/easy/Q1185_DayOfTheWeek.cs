class Q1185_DayOfTheWeek
{
    // TC: O(1),
    // SC: O(1),
    public string DayOfTheWeek(int day, int month, int year)
    {
        var date = new DateOnly(year, month, day);
        return date.DayOfWeek.ToString();
    }
}
class Q1185_DayOfTheWeekTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [31, 8, 2019, "Saturday"],
        [18, 7, 1999, "Sunday"],
        [15, 8, 1993, "Sunday"],
    ];
}
public class Q1185_DayOfTheWeekTests
{
    [Theory]
    [ClassData(typeof(Q1185_DayOfTheWeekTestData))]
    public void OfficialTestCases(int day, int month, int year, string expected)
    {
        var sut = new Q1185_DayOfTheWeek();
        var actual = sut.DayOfTheWeek(day, month, year);
        Assert.Equal(expected, actual);
    }
}
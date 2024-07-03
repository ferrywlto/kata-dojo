class Q1360_NumberOfDaysBetweenTwoDates
{
    // TC: O(1)
    // SC: O(1), obviously
    public int DaysBetweenDates(string date1, string date2)
    {
        // use built-in functions
        var d1 = DateTime.ParseExact(date1, "yyyy-MM-dd", null);
        var d2 = DateTime.ParseExact(date2, "yyyy-MM-dd", null);
        var d3 = d1 - d2;
        return (int)Math.Abs(d3.TotalDays);
    }
}
class Q1360_NumberOfDaysBetweenTwoDatesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["2019-06-29", "2019-06-30", 1],
        ["2020-01-15", "2019-12-31", 15],
    ];
}
public class Q1360_NumberOfDaysBetweenTwoDatesTests
{
    [Theory]
    [ClassData(typeof(Q1360_NumberOfDaysBetweenTwoDatesTestData))]
    public void OfficialTestCases(string input1, string input2, int expected)
    {
        var sut = new Q1360_NumberOfDaysBetweenTwoDates();
        var actual = sut.DaysBetweenDates(input1, input2);
        Assert.Equal(expected, actual);
    }
}
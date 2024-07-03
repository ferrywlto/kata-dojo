class Q1360_NumberOfDaysBetweenTwoDates
{
    public int DaysBetweenDates(string date1, string date2)
    {
        return 0;
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
class Q1154_DayOfTheYear
{
    // TC: O(1)
    // SC: O(1)
    public int DayOfYear(string date)
    {
        var dateObj = DateOnly.ParseExact(date, "yyyy-MM-dd");
        return dateObj.DayOfYear;
    }

    private Dictionary<int, int> daysInMonth = new() {
        {1,31},
        {2,28},
        {3,31},
        {4,30},
        {5,31},
        {6,30},
        {7,31},
        {8,31},
        {9,30},
        {10,31},
        {11,30},
        {12,31},
    };

    public int DayOfYear_ReinventTheWheel(string date)
    {
        var parts = date.Split("-");
        var year = int.Parse(parts[0]);
        var month = int.Parse(parts[1]);
        var day = int.Parse(parts[2]);

        var daysSinceYearStart = 0;
        // current month not added because we will add days
        for (var i = 1; i < month; i++)
        {
            daysSinceYearStart += daysInMonth[i];
        }

        if (month <= 2)
            return daysSinceYearStart + day;

        // check leap year
        if
        (
            (year % 400 == 0) ||
            (year % 4 == 0 && year % 100 != 0)
        ) daysSinceYearStart++;

        return daysSinceYearStart + day;
    }
}
class Q1154_DayOfTheYearTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["2019-01-09", 9],
        ["2019-02-10", 41],
        ["1900-05-02", 122],
    ];
}
public class Q1154_DayOfTheYearTests
{
    [Theory]
    [ClassData(typeof(Q1154_DayOfTheYearTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1154_DayOfTheYear();
        var actual = sut.DayOfYear_ReinventTheWheel(input);
        Assert.Equal(expected, actual);
    }
}

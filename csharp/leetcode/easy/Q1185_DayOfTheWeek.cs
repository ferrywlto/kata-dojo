class Q1185_DayOfTheWeek
{
    // TC: O(1),
    // SC: O(1),
    public string DayOfTheWeek(int day, int month, int year)
    {
        var date = new DateOnly(year, month, day);
        return date.DayOfWeek.ToString();
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
    private Dictionary<int, string> Weekdays = new() {
        {0, "Sunday"},
        {1, "Monday"},
        {2, "Tuesday"},
        {3, "Wednesday"},
        {4, "Thursday"},
        {5, "Friday"},
        {6, "Saturday"},
    };

    // Add manual way without built-in function for reference
    public string DayOfTheWeek_Handcraft(int day, int month, int year)
    {
        //1900/01/01 is Monday

        // get number of leap year
        var numLeapYear = 0;
        for(var i = 1900; i < year; i++)
        {
            if (IsLeapYear(i)) numLeapYear++;
        }
        var daysBeforeInputYear = ((year - 1900) * 365) + numLeapYear;

        var daysSinceYearStart = 0; 
        for(var i=1; i<month; i++)
        {
            daysSinceYearStart += daysInMonth[i];
        }
        daysSinceYearStart += day;

        if (IsLeapYear(year) && month > 2) daysSinceYearStart++;

        var totalDays = daysBeforeInputYear + daysSinceYearStart;
        return Weekdays[totalDays % 7];
    }

    static bool IsLeapYear(int year) => year % 400 == 0 || (year % 100 != 0 && year % 4 == 0);
}
class Q1185_DayOfTheWeekTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [31, 8, 2019, "Saturday"],
        [18, 7, 1999, "Sunday"],
        [15, 8, 1993, "Sunday"],
        [1, 1, 1900, "Monday"],
    ];
}
public class Q1185_DayOfTheWeekTests
{
    [Theory]
    [ClassData(typeof(Q1185_DayOfTheWeekTestData))]
    public void OfficialTestCases(int day, int month, int year, string expected)
    {
        var sut = new Q1185_DayOfTheWeek();
        var actual = sut.DayOfTheWeek_Handcraft(day, month, year);
        Assert.Equal(expected, actual);
    }
}
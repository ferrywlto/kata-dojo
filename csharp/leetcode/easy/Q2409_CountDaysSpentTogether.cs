public class Q2409_CountDaysSpentTogether
{
    public readonly Dictionary<int, int> daysBeforeMonth = new Dictionary<int, int>() {
        {1,0},
        {2,31},
        {3,59},
        {4,90},
        {5,120},
        {6,151},
        {7,181},
        {8,212},
        {9,243},
        {10,273},
        {11,304},
        {12,334},
    };
    // TC: O(1), time used are fixed
    // SC: O(1), space used does not scale with input
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        var dayInYearArriveAlice = ParseDayInYear(arriveAlice);
        var dayInYearArriveBob = ParseDayInYear(arriveBob);
        var dayInYearLeaveAlice = ParseDayInYear(leaveAlice);
        var dayInYearLeaveBob = ParseDayInYear(leaveBob);

        var secondArrival = Math.Max(dayInYearArriveAlice, dayInYearArriveBob);
        var firstLeave = Math.Min(dayInYearLeaveAlice, dayInYearLeaveBob);

        if (dayInYearArriveBob > dayInYearLeaveAlice ||
        dayInYearArriveAlice > dayInYearLeaveBob) return 0;

        var together = firstLeave - secondArrival + 1;

        return together;
    }
    public int ParseDay(string input) => int.Parse(input[3..5]);
    public int ParseMonth(string input) => int.Parse(input[0..2]);
    public int ParseDayInYear(string input) =>
        ParseDay(input) + daysBeforeMonth[ParseMonth(input)];

    public static List<object[]> TestData =>
    [
        ["08-15", "08-18", "08-16", "08-19", 3],
        ["08-15", "08-15", "08-15", "08-15", 1],
        ["10-01", "10-31", "11-01", "12-31", 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string arriveA, string leaveA, string arriveB, string leaveB, int expected)
    {
        var actual = CountDaysTogether(arriveA, leaveA, arriveB, leaveB);
        Assert.Equal(expected, actual);
    }
}

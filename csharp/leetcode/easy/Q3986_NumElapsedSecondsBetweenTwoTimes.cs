public class Q3986_NumElapsedSecondsBetweenTwoTimes
{
    // TC: O(1)
    // SC: O(1)
    public int SecondsBetweenTimes(string startTime, string endTime)
    {
        return ToSeconds(endTime) - ToSeconds(startTime);
    }

    private int ToSeconds(string input)
    {
        if (input.Length != 8) return 0;

        var startHour = charOffSet(input[0]) * 10 + charOffSet(input[1]);
        var starHourSeconds = startHour * 3600;

        var startMins = charOffSet(input[3]) * 10 + charOffSet(input[4]);
        var startMinSeconds = startMins * 60;

        return starHourSeconds + startMinSeconds + charOffSet(input[6]) * 10 +
                            charOffSet(input[7]);
    }

    private int charOffSet(char input) => input - '0';

    public static TheoryData<string, string, int> TestData => new()
    {
        { "01:00:00", "01:00:25", 25 },
        { "12:34:56", "13:00:00", 1504 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string start, string end, int expected)
    {
        var actual = SecondsBetweenTimes(start, end);
        Assert.Equal(expected, actual);
    }
}

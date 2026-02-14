public class Q2437_NumberOfValidClockTimes//(ITestOutputHelper output)
{
    // TC: O(1), time to compute is constant
    // SC: O(1), space used does not scale with input 
    public int CountTime(string time)
    {
        if (time[0] != '?' &&
            time[1] != '?' &&
            time[3] != '?' &&
            time[4] != '?') return 1;

        var hVariation = 0;
        if (time[0] == '?' && time[1] == '?') hVariation = 24;
        else if (time[1] == '?')
        {
            var firstDigit = time[0] - '0';
            if (firstDigit < 2) hVariation = 10;
            else hVariation = 4;
        }
        else if (time[0] == '?')
        {
            var secondDigit = time[1] - '0';
            if (secondDigit < 4) hVariation = 3;
            else hVariation = 2;
        }

        var mVariation = 0;
        if (time[3] == '?' && time[4] == '?') mVariation = 60;
        else if (time[4] == '?') mVariation = 10;
        else if (time[3] == '?') mVariation = 6;

        return hVariation > 0 && mVariation > 0
            ? hVariation * mVariation
            : hVariation + mVariation;
    }
    public static List<object[]> TestData =>
    [
        ["?5:00", 2],
        ["0?:0?", 100],
        ["??:??", 1440],
        ["??:00", 24],
        ["23:??", 60],
        ["21:08", 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountTime(input);
        Assert.Equal(expected, actual);
    }
}

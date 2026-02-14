public class Q2224_MinNumberOfOperationsToConvertTime
{
    // TC: O(1), operations are static each run
    // SC: O(1), space used does not scale with input
    public int ConvertTime(string current, string correct)
    {
        var minutesInCorrect = ToMinutes(correct);
        var minutesInCurrent = ToMinutes(current);
        var diffInMinutes = minutesInCorrect - minutesInCurrent;

        var result = 0;
        var intervals = new int[] { 60, 15, 5 };
        for (var i = 0; i < intervals.Length; i++)
        {
            var minutes = intervals[i];
            if (diffInMinutes >= minutes)
            {
                result += diffInMinutes / minutes;
                diffInMinutes %= minutes;
            }
        }

        result += diffInMinutes;
        return result;
    }
    private int ToMinutes(string input)
    {
        return ((input[0] - '0') * 10 + (input[1] - '0')) * 60
         + (input[3] - '0') * 10 + (input[4] - '0');
    }
    public static List<object[]> TestData =>
    [
        ["02:30", "04:35", 3],
        ["11:00", "11:01", 1],
        ["09:41", "10:34", 7],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, int expected)
    {
        var actual = ConvertTime(input1, input2);
        Assert.Equal(expected, actual);
    }
}

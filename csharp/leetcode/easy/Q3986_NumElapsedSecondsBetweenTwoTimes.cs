public class Q3986_NumElapsedSecondsBetweenTwoTimes
{
    public int SecondsBetweenTimes(string startTime, string endTime)
    {
        return 0;
    }

    public static TheoryData<string, string, int> TestData => new () {
        {
            "01:00:00", "01:00:25", 25
        },
        {
            "12:34:56", "13:00:00", 1504
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string start, string end, int expected)
    {
        var actual = SecondsBetweenTimes(start, end);
        Assert.Equal(expected, actual);
    }
}

public class Q2437_NumberOfValidClockTimes
{
    public int CountTime(string time)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["?5:00", 2],
        ["0?:0?", 100],
        ["??:??", 1440],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountTime(input);
        Assert.Equal(expected, actual);
    }
}
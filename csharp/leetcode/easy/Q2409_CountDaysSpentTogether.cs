public class Q2409_CountDaysSpentTogether
{
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["08-15", "08-18", "08-16", "08-19", 3],
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
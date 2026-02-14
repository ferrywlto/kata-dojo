public class Q2446_DetermineIfTwoEventsHaveConflict
{
    // TC: O(1), time used in operation is does not scale with input
    // SC: O(1), same as time
    public bool HaveConflict(string[] event1, string[] event2)
    {
        var t1_start = GetTimeInMinutes(event1[0]);
        var t1_end = GetTimeInMinutes(event1[1]);

        var t2_start = GetTimeInMinutes(event2[0]);
        var t2_end = GetTimeInMinutes(event2[1]);

        var laterStart = Math.Max(t1_start, t2_start);
        var soonerEnd = Math.Min(t1_end, t2_end);

        return soonerEnd >= laterStart;
    }
    private int GetTimeInMinutes(string input)
    {
        var h1_start = int.Parse(input[..2]);
        var m1_start = int.Parse(input[3..]);
        return h1_start * 60 + m1_start;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"01:15","02:00"}, new string[] {"02:00","03:00"}, true],
        [new string[] {"01:00","02:00"}, new string[] {"01:20","03:00"}, true],
        [new string[] {"10:00","11:00"}, new string[] {"14:00","15:00"}, false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] event1, string[] event2, bool expected)
    {
        var actual = HaveConflict(event1, event2);
        Assert.Equal(expected, actual);
    }
}

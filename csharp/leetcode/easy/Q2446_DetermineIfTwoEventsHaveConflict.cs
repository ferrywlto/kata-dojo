public class Q2446_DetermineIfTwoEventsHaveConflict
{
    public bool HaveConflict(string[] event1, string[] event2)
    {
        return false;
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
public class Q3894_TrafficSingalColor
{
    // TC: O(1)
    // SC: O(1)
    public string TrafficSignal(int timer)
    {
        return timer switch
        {
            0 => "Green",
            30 => "Orange",
            > 30 and <= 90 => "Red",
            _ => "Invalid"
        };
    }

    public static TheoryData<int, string> TestData => new() { { 60, "Red" }, { 5, "Invalid" }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, string expected)
    {
        var actual = TrafficSignal(input);
        Assert.Equal(expected, actual);
    }
}

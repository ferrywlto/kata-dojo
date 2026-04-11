public class Q3894_TrafficSingalColor
{
    public string TrafficSignal(int timer)
    {
        return "";
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

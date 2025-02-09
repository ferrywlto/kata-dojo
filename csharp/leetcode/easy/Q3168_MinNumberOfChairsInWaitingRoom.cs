public class Q3168_MinNumberOfChairsInWaitingRoom
{
    public int MinimumChairs(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"EEEEEEE", 7},
        {"ELELEEL", 2},
        {"ELEELEELLL", 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinimumChairs(input);
        Assert.Equal(expected, actual);
    }
}
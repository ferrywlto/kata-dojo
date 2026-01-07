public class Q2405_OptimalPartitionOfString
{
    public int PartitionString(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abacaba", 4},
        {"ssssss", 6},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = PartitionString(input);
        Assert.Equal(expected, actual);
    }
}

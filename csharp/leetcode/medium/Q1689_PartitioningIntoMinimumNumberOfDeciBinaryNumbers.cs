public class Q1689_PartitioningIntoMinimumNumberOfDeciBinaryNumbers
{
    public int MinPartitions(string n)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"32", 3},
        {"82734", 8},
        {"27346209830709182346", 9},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinPartitions(input);
        Assert.Equal(expected, actual);
    }
}
public class Q1689_PartitioningIntoMinimumNumberOfDeciBinaryNumbers
{
    // TC: O(n), n scale with length of n
    // SC: O(1), space used does not scale with input
    public int MinPartitions(string n)
    {
        var max = 0;
        for (var i = 0; i < n.Length; i++)
        {
            if (n[i] > max) max = n[i];
        }
        return max - '0';
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
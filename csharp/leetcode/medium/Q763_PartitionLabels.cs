public class Q763_PartitionLabels
{
    public IList<int> PartitionLabels(string s)
    {
        var lastOccurrence = new int[26];

    }
    public static TheoryData<string, int[]> TestData => new()
    {
        {"ababcbacadefegdehijhklij",  [9, 7, 8]  },
        { "eccbbbbdec", [10] },
        { "a", [1] },
        { "ab", [1, 1] },
        { "abcde",  [1, 1, 1, 1, 1] }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, int[] expected)
    {
        var actual = PartitionLabels(s);
        Assert.Equal(expected, actual);
    }
}
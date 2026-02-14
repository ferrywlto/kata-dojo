public class Q2405_OptimalPartitionOfString
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int PartitionString(string s)
    {
        /* 
        It could potentially faster with
        Span<bool> seen = stackalloc bool[26];
        and
        seen.Clear()
        such that c - 'a' calculation can be avoided.
        */
        var freq = new int[26];
        var segmentCount = 1;
        foreach (var c in s)
        {
            if (freq[c - 'a'] == 1)
            {
                segmentCount++;
                Array.Clear(freq);
            }
            freq[c - 'a']++;
        }
        return segmentCount;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abacaba", 4},
        {"ssssss", 6},
        {"hdklqkcssgxlvehva", 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = PartitionString(input);
        Assert.Equal(expected, actual);
    }
}

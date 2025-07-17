public class Q763_PartitionLabels
{
    // TC: O(n), n scale with the length of the string
    // SC: O(n) if we consider the output as well, O(1) otherwise
    public IList<int> PartitionLabels(string s)
    {
        var result = new List<int>();
        var lastOccurrence = new int[26];

        for (var i = 0; i < s.Length; i++)
        {
            var index = s[i] - 'a';
            lastOccurrence[index] = i;
        }

        var lastIdx = 0;
        var currentPartLastIdx = lastOccurrence[s[0] - 'a'];
        for (var i = 0; i < s.Length; i++)
        {
            currentPartLastIdx = Math.Max(currentPartLastIdx, lastOccurrence[s[i] - 'a']);
            if (i == currentPartLastIdx)
            {
                var idx = i - lastIdx;
                result.Add(idx);
                lastIdx = i;
            }
        }
        // For unknown reason, the first partition is one less than expected
        result[0]++;
        return result;
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
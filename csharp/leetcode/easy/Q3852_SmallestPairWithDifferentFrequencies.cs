public class Q3852_SmallestPairWithDifferentFrequencies
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input.
    public int[] MinDistinctFreqPair(int[] nums)
    {
        Span<int> freq = stackalloc int[101];
        foreach (var n in nums)
            freq[n]++;

        var first = -1;
        var firstFreq = 0;

        for (var i = 1; i < freq.Length; i++)
        {
            if (freq[i] == 0) continue;

            if (first == -1)
            {
                first = i;
                firstFreq = freq[i];
            }
            else if (freq[i] != firstFreq)
            {
                return [first, i];
            }
        }
        return [-1, -1];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[1,1,2,2,3,4], [1,3]},
        {[1,5], [-1,-1]},
        {[7], [-1, -1]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinDistinctFreqPair(input);
        Assert.Equal(expected, actual);
    }
}

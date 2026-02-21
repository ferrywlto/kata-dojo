public class Q3843_FirstElementWithUniqueFrequency
{
    // TC: O(n), n scale with length of num
    // SC: O(n + f + d), n scale with unique numbers in num, f scale with unique frequencies, d scale with number of frequency count is 1
    public int FirstUniqueFreq(int[] nums)
    {
        var freq = new Dictionary<int, int>();
        var bucket = new Dictionary<int, List<int>>();

        foreach (var n in nums)
        {
            if (freq.TryGetValue(n, out var val))
            {
                freq[n] = ++val;
            }
            else
            {
                freq.Add(n, 1);
            }
        }

        foreach (var (key, value) in freq)
        {
            if (bucket.TryGetValue(value, out var list))
            {
                list.Add(key);
            }
            else
            {
                bucket.Add(value, [key]);
            }
        }

        var uniqueFreqSet = new HashSet<int>();

        foreach (var b in bucket)
        {
            if (b.Value.Count == 1)
            {
                uniqueFreqSet.Add(b.Value[0]);
            }
        }

        if (uniqueFreqSet.Count == 0) return -1;

        for (var i = 0; i < nums.Length; i++)
        {
            if (uniqueFreqSet.Contains(nums[i]))
                return nums[i];
        }

        return -1;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[20,10,30,30], 30},
        {[20,20,10,30,30,30], 20},
        {[10,10,20,20], -1}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FirstUniqueFreq(input);
        Assert.Equal(expected, actual);
    }
}

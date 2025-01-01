public class Q2784_CheckIfArrayIsGood
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public bool IsGood(int[] nums)
    {
        var freq = new Dictionary<int, int>();
        var max = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            if (current > max)
            {
                max = current;
            }

            if (freq.TryGetValue(current, out var val))
            {
                freq[current] = ++val;
            }
            else
            {
                freq.Add(current, 1);
            }
        }
        if (freq[max] != 2) return false;
        for (var i = 1; i < max; i++)
        {
            if (!freq.TryGetValue(i, out var val) || val != 1)
            {
                return false;
            }
        }
        return true;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[2, 1, 3], false},
        {[1, 3, 3, 2], true},
        {[1, 1], true},
        {[3, 4, 4, 1, 2, 1], false},
        {[9, 9], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = IsGood(input);
        Assert.Equal(expected, actual);
    }
}
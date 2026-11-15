public class Q4111_countConsistentSubarraysI
{
    // Using DP with a list
    // TC: O(n), where n = ((1+n)*n) / 2
    // SC: O(n) the list grow to at most n items
    public int CountConsistent(int[] nums)
    {
        // each single item subarray must consistent
        var result = nums.Length;

        Span<int> mins = stackalloc int[nums.Length];
        Span<int> list = stackalloc int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            mins[i] = nums[i];
            list[i] = nums[i];
        }

        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                mins[j] = Math.Min(mins[j], nums[i]);
                list[j] &= nums[i];

                if (list[j] == mins[j])
                    result++;
            }
        }
        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [5, 3, 1, 2], 6 },
        { [1, 1, 1], 6 },
        { [0], 1 },
        { [0, 4, 1], 5}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountConsistent(input);
        Assert.Equal(expected, actual);
    }
}

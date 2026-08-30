public class Q4038_CountIntegersAppearingInSingleBlock
{
    // TC: O(n)
    // SC: O(1)
    public int CountSpecialIntegers(int[] nums)
    {
        Span<int> seen = stackalloc int[101];

        for (var i = 1; i < nums.Length; i++)
        {
            // record a new truck
            if (nums[i] != nums[i - 1])
            {
                seen[nums[i - 1]] = seen[nums[i - 1]] switch
                {
                    // 0 means unseen
                    // 1 means seen
                    // -1 means seen more than once
                    0 => 1,
                    1 => -1,
                    _ => seen[nums[i - 1]]
                };
            }
        }

        seen[nums[^1]] = seen[nums[^1]] switch
        {
            // Handle the last element
            0 => 1,
            1 => -1,
            _ => seen[nums[^1]]
        };

        var result = 0;
        foreach (var t in seen)
            if (t == 1)
                result++;

        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 2, 2, 1], 1 },
        { [3, 3, 1, 2, 2, 1], 2 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountSpecialIntegers(input);
        Assert.Equal(expected, actual);
    }
}

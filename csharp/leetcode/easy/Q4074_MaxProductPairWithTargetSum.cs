public class Q4074_MaxProductPairWithTargetSum
{
    // TC: O(n)
    // SC: O(n), worst case all numbers are unique
    public int[] MaxProductPair2(int[] nums, int target)
    {
        var seen = new Dictionary<int, int>();
        int max = int.MinValue;
        int[] result = [-1, -1];

        for (var i = 0; i < nums.Length; i++)
        {
            // The tricks here is to find if any seen can form a valid pair, if not then skip it. Which reduce O(n^2) to O(n)
            var partner = target - nums[i];

            if (partner == nums[i]) continue;
            if (!seen.TryGetValue(partner, out int idx))
            {
                seen.TryAdd(nums[i], i);
                continue;
            }

            var prod = nums[i] * partner;
            if (prod > max)
            {
                max = prod;
                if (nums[i] > partner)
                {
                    result[0] = i;
                    result[1] = idx;
                }
                else
                {
                    result[0] = idx;
                    result[1] = i;
                }
            }

            seen.TryAdd(nums[i], i);
        }

        return result;
    }

    public static TheoryData<int[], int, int[]> TestData => new()
    {
        { [1, 2, 3, 4], 5, [2, 1] },
        { [-3, -1, 4, 2], 1, [3, 1] },
        { [3, 3, 5], 6, [-1, -1] },
        { [1, -6], -5, [0, 1] },
        { [2, 2], -6, [0, 1] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int target, int[] expected)
    {
        var actual = MaxProductPair2(input, target);
        Assert.Equal(expected, actual);
    }
}

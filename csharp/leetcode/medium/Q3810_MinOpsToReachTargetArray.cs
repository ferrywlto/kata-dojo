public class Q3810_MinOpsToReachTargetArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(1)
    // The technique is the confusing description, the maximum contiguous sequence is just for any subsequence of the same value, fill the sequence with values from target at the same positions.
    // Then the description become pick a number in nums, replace all values with target at the same position.
    // Therefore the answer is number of distinct values in nums that is different from target. (distinct because all of the same values will become target in single operation.)
    public int MinOperations(int[] nums, int[] target)
    {
        // Constraint max length is 100000, thus size need to be 100001
        Span<int> freq = stackalloc int[100_001];

        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != target[i])
            {
                if (++freq[nums[i]] == 1)
                {
                    result++;
                }
            }
        }
        return result;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {
        {[1,2,3], [2,1,3], 2},
        {[4,1,4], [5,1,4], 1},
        {[7,3,7], [5,5,9], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int[] target, int expected)
    {
        var actual = MinOperations(nums, target);
        Assert.Equal(expected, actual);
    }
}

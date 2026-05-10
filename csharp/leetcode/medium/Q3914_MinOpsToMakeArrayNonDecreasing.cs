public class Q3914_MinOpsToMakeArrayNonDecreasing
{
    // TC: O(n), n scale with length of nums
    // SC: O(1) space used does not scale with input
    public long MinOperations(int[] nums)
    {
        long result = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                result += nums[i - 1] - nums[i];
            }
        }
        return result;
    }

    public static TheoryData<int[], int> TestData = new()
    {
        { [3, 3, 2, 1], 2 },
        { [5, 1, 2, 3], 4 },
        { [12, 1, 14], 11 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

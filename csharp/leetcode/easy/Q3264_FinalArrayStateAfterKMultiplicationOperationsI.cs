public class Q3264_FinalArrayStateAfterKMultiplicationOperationsI
{
    // TC: O(n * k), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        for (var i = 0; i < k; i++)
        {
            var minIdx = 0;
            var min = nums[0];
            for (var j = 1; j < nums.Length; j++)
            {
                if (nums[j] < min)
                {
                    min = nums[j];
                    minIdx = j;
                }
            }
            nums[minIdx] *= multiplier;
        }
        return nums;
    }
    public static TheoryData<int[], int, int, int[]> TestData => new()
    {
        {[2,1,3,5,6], 5, 2, [8,4,6,5,6]},
        {[1,2], 3, 4, [16,8]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int m, int[] expected)
    {
        var actual = GetFinalState(input, k, m);
        Assert.Equal(expected, actual);
    }
}
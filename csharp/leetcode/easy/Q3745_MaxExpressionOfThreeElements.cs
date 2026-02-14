public class Q3745_MaxExpressionOfThreeElements
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input size

    public int MaximizeExpressionOfThree(int[] nums)
    {
        var max = int.MinValue;
        var secondMax = int.MinValue;
        var min = int.MaxValue;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max)
            {
                secondMax = max;
                max = nums[i];
            }
            else if (nums[i] > secondMax)
            {
                secondMax = nums[i];
            }
            if (nums[i] < min)
            {
                min = nums[i];
            }
        }
        return max + secondMax - min;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        { [1,4,2,5], 8},
        { [-2,0,5,-2,4], 11},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var result = MaximizeExpressionOfThree(nums);
        Assert.Equal(expected, result);
    }
}

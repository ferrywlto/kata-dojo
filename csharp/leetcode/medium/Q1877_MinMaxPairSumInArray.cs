public class Q1877_MinMaxPairSumInArray
{
    // TC: O(n log n) due to sort
    // SC: O(1), space used does not scale with input
    public int MinPairSum(int[] nums)
    {
        Array.Sort(nums);
        var max = int.MinValue;
        var len = nums.Length;
        var half = nums.Length / 2;

        for (var i = 0; i < half; i++)
        {
            max = Math.Max(max, nums[i] + nums[len - i - 1]);
        }

        return max;
    }
    // 2,3,3,5
    // Onces sorted, adding largest with smallest can keep the sum as minimized
    public static TheoryData<int[], int> TestData => new()
    {
        { [3, 5, 2, 3], 7 },
        { [3, 5, 4, 2, 4, 6], 8 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinPairSum(input);
        Assert.Equal(expected, actual);
    }
}
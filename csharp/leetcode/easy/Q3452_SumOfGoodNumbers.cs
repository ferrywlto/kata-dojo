public class Q3452_SumOfGoodNumbers
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int SumOfGoodNumbers(int[] nums, int k)
    {
        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var leftIsGood = i < k || (i >= k && nums[i] > nums[i - k]);
            var rightIsGood = i + k >= nums.Length || (i + k < nums.Length && nums[i] > nums[i + k]);
            if (leftIsGood && rightIsGood)
            {
                result += nums[i];
            }
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[1,3,2,1,5,4], 2, 12},
        {[2,1], 1, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = SumOfGoodNumbers(input, k);
        Assert.Equal(expected, actual);
    }
}

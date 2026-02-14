public class Q2908_MinSumOfMountainTripletsI
{
    // TC: O(n^3), n scale with length of nums because of triplets
    // SC: O(1), space used does not sacle with input
    public int MinimumSum(int[] nums)
    {
        var min = int.MaxValue;
        for (var i = 0; i < nums.Length - 2; i++)
        {
            for (var j = i + 1; j < nums.Length - 1; j++)
            {
                for (var k = j + 1; k < nums.Length; k++)
                {
                    if (nums[i] < nums[j] && nums[k] < nums[j])
                    {
                        var sum = nums[i] + nums[j] + nums[k];
                        if (sum < min)
                        {
                            min = sum;
                        }
                    }
                }
            }
        }
        if (min == int.MaxValue) return -1;
        return min;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[8,6,1,5,3], 9},
        {[5,4,8,7,10,2], 13},
        {[6,5,4,3,4,5], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumSum(input);
        Assert.Equal(expected, actual);
    }
}

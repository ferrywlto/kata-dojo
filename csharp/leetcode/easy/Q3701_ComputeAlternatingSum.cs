public class Q3701_ComputeAlternatingSum
{
    // TC: O(n), n is the length of nums
    // SC: O(1), space used does not scale with input size
    public int AlternatingSum(int[] nums)
    {
        var oddSum = 0;
        var evenSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0) // even index
            {
                evenSum += nums[i];
            }
            else
            {
                oddSum += nums[i];
            }
        }
        return evenSum - oddSum;
    }
    public static TheoryData<int[], int> TestData => new()
    {
      { [1,3,5,7], -4},
      { [100], 100},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var result = AlternatingSum(nums);
        Assert.Equal(expected, result);
    }
}

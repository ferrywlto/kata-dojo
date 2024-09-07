class Q1800_MaxAscendingSubarraySum
{
    // TC: O(n), where n is the length of nums
    // SC: O(1), space used is fixed
    public int MaxAscendingSum(int[] nums)
    {
        var maxSum = 0;
        var currentSum = 0;
        var previousNum = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > previousNum) currentSum += nums[i];
            else
            {
                if (currentSum > maxSum) maxSum = currentSum;

                currentSum = nums[i];
            }
            previousNum = nums[i];
        }
        return currentSum > maxSum ? currentSum : maxSum;
    }
}
class Q1800_MaxAscendingSubarraySumTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {10,20,30,5,10,50}, 65],
        [new int[] {10,20,30,40,50}, 150],
        [new int[] {12,17,15,13,10,11,12}, 33],
        [new int[] {100,17,15,13,10,11,12,13}, 100],
    ];
}
public class Q1800_MaxAscendingSubarraySumTests
{
    [Theory]
    [ClassData(typeof(Q1800_MaxAscendingSubarraySumTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1800_MaxAscendingSubarraySum();
        var actual = sut.MaxAscendingSum(input);
        Assert.Equal(expected, actual);
    }
}
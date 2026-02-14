public class Q3190_FindMinOpsToMakeAllElementsDivisibleByThree
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MinimumOperations(int[] nums)
    {
        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 3 != 0) result++;
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4], 3},
        {[3,6,9], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}

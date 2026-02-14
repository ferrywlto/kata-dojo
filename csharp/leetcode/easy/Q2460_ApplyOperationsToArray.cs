public class Q2460_ApplyOperationsToArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), same as time to hold the result
    public int[] ApplyOperations(int[] nums)
    {
        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] != nums[i + 1]) continue;

            nums[i] *= 2;
            nums[i + 1] = 0;
        }
        var nonZeroCount = 0;
        var result = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                result[nonZeroCount++] = nums[i];
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,2,1,1,0}, new int[] {1,4,2,0,0,0}],
        [new int[] {0,1}, new int[] {1,0}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = ApplyOperations(input);
        Assert.Equal(expected, actual);
    }
}

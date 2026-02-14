public class Q3038_MaxNumberOperationsWithSameScoreI
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MaxOperations(int[] nums)
    {
        var result = 1;
        var score = nums[0] + nums[1];
        for (var i = 2; i < nums.Length; i += 2)
        {
            if (
                i == nums.Length - 1 ||
                nums[i] + nums[i + 1] != score
            ) return result;

            result++;
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,2,1,4,5], 2},
        {[1,5,3,3,4,1,3,2,2,3], 2},
        {[5,3], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxOperations(input);
        Assert.Equal(expected, actual);
    }
}

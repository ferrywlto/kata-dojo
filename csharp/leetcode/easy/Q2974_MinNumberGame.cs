public class Q2974_MinNumberGame
{
    // TC: O(n log n), n scale with length of nums due to Array.Sort()
    // SC: O(n), n scale with length of nums to hold the result
    public int[] NumberGame(int[] nums)
    {
        Array.Sort(nums);
        var result = new int[nums.Length];
        for (var i = 0; i < nums.Length; i += 2)
        {
            result[i] = nums[i + 1];
            result[i + 1] = nums[i];
        }
        return result;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[5,4,2,3], [3,2,5,4]},
        {[2,5], [5,2]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = NumberGame(input);
        Assert.Equal(expected, actual);
    }
}

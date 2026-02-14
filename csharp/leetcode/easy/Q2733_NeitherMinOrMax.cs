public class Q2733_NeitherMinOrMax//(ITestOutputHelper output)
{
    // TC: O(n log n), due to Array.Sort()
    // SC: O(1), space used does not scale with input
    public int FindNonMinOrMax(int[] nums)
    {
        if (nums.Length <= 2) return -1;
        Array.Sort(nums, 0, 3);
        return nums[1];
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,2,1,4], 2},
        {[1,2], -1},
        {[2,1,3], 2},
        {[3,30,24], 24},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindNonMinOrMax(input);
        Assert.Equal(expected, actual);
    }
}

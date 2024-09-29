public class Q1991_FindMiddleIndexInArray
{
    // TC: O(n), n scale with length of nums, n for first sum, another n to find the middle idx
    // SC: O(1), space used does not sacle with nums
    public int FindMiddleIndex(int[] nums)
    {
        if (nums.Length == 1) return 0;
        var total = nums.Sum();
        var currentSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            total -= nums[i];
            if (currentSum == total) return i;
            currentSum += nums[i];
        }
        return -1;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {2,3,-1,8,4}, 3],
        [new int[] {1,-1,4}, 2],
        [new int[] {2,5}, -1],
        [new int[] {9}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindMiddleIndex(input);
        Assert.Equal(expected, actual);
    }
}
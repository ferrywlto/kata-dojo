public class Q2357_MakeArrayZeroBySubstractingEqualAmounts
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int MinimumOperations(int[] nums)
    {
        var set = new HashSet<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0) set.Add(nums[i]);
        }
        return set.Count;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,5,0,3,5}, 3],
        [new int[] {0}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}
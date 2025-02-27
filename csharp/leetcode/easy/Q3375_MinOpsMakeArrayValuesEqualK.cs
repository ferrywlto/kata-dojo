public class Q3375_MinOpsMakeArrayValuesEqualK
{
    // TC: O(n), n sacle with length of nums
    // SC: O(m), m sacle with unique numbers in nums
    public int MinOperations(int[] nums, int k)
    {
        var set = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] < k) return -1;
            else if (nums[i] > k) set.Add(nums[i]);
        }
        return set.Count();
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[5,2,5,4,5], 2, 2},
        {[2,1,2], 2, -1},
        {[9,7,5,3], 1, 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}
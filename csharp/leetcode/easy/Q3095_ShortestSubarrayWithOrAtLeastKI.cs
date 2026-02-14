public class Q3095_ShortestSubarrayWithOrAtLeastKI
{
    // TC: O(n^3), n scale with length of nums
    // SC: O(1)
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        var size = 0;
        while (size < nums.Length)
        {
            for (var i = 0; i < nums.Length - size; i++)
            {
                if (Or(nums, i, size) >= k) return size + 1;
            }
            size++;
        }
        return -1;
    }
    private int Or(int[] input, int startIdx, int size)
    {
        if (input.Length == 1) return input[startIdx];

        var result = 0;
        for (var i = startIdx; i <= startIdx + size; i++)
        {
            result |= input[i];
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[1,2,3], 2, 1},
        {[2,1,8], 10, 3},
        {[1,2], 0, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinimumSubarrayLength(input, k);
        Assert.Equal(expected, actual);
    }
}

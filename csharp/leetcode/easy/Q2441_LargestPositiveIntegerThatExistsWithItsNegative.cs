public class Q2441_LargestPositiveIntegerThatExistsWithItsNegative
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), n sacle with lengtb of nums
    public int FindMaxK(int[] nums)
    {
        var set = new HashSet<int>();
        var max = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            set.Add(nums[i]);
            if (set.Contains(nums[i] * -1))
            {
                var abs = Math.Abs(nums[i]);
                if (abs > max) max = abs;
            }
        }
        return max == int.MinValue ? -1 : max;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {-1,2,-3,3}, 3],
        [new int[] {-1,10,6,7,-7,1}, 7],
        [new int[] {-10,8,6,7,-2,-3}, -1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindMaxK(input);
        Assert.Equal(expected, actual);
    }
}
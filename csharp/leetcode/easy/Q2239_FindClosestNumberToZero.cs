public class Q2239_FindClosestNumberToZero
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int FindClosestNumber(int[] nums)
    {
        var minDiff = int.MaxValue;
        for (var i = 0; i < nums.Length; i++)
        {
            var diff = Math.Abs(nums[i]);
            if (diff < minDiff) minDiff = diff;
        }
        var largest = int.MinValue;
        foreach (var n in nums)
        {
            if (Math.Abs(n) == minDiff && n > largest) largest = n;
        }
        return largest;
    }
    public static List<object[]> TestData =>
    [
        [new int[]{-4,-2,1,4,8}, 1],
        [new int[]{2,-1,1}, 1],
        [new int[]{-100000,-100000}, -100000],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindClosestNumber(input);
        Assert.Equal(expected, actual);
    }
}

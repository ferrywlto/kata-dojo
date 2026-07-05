public class Q3974_MaxTotalSumOfKSelectedElements
{
    // TC: O(n log n)
    // SC: O(1)
    // Since k can be equals to nums.Length, using full sort is pragmatic rather than over-fitting leetcode test cases.
    // Use top K heap only if k explicitly <<< nums.Length to reduce unnecessary sorting the num.Length - k numbers.
    public long MaxSum(int[] nums, int k, int mul)
    {
        Array.Sort(nums);
        var result = 0L;
        var start = nums.Length - 1;
        var end = start - k;
        for (var i = start; i > end; i--)
        {
            if (mul >= 2)
                result += (long)nums[i] * mul;
            else
                result += nums[i];
            mul--;
        }
        return result;
    }

    public static TheoryData<int[], int, int, int> TestData => new()
    {
        { [6, 1, 2, 9], 3, 2, 26 },
        { [3, 7, 5, 2], 2, 4, 43 },
        { [4, 4], 1, 1, 4 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int mul, int expected)
    {
        var actual = MaxSum(input, k, mul);
        Assert.Equal(expected, actual);
    }
}

public class Q3684_MaxSumOfAtMostKDistinctElements
{
    // TC: O(N log N), dominated by sorting
    // SC: O(k), for the result list, worst case k equals number of distinct elements
    public int[] MaxKDistinct(int[] nums, int k)
    {
        // Sort descending
        Array.Sort(nums, (a, b) => b - a);

        var result = new List<int>();
        var idx = 0;

        result.Add(nums[0]);
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != result[idx] && result.Count < k)
            {
                result.Add(nums[i]);
                idx++;
            }
        }
        return result.ToArray();
    }
    public static TheoryData<int[], int, int[]> TestData =>
        new()
        {
            { [84,93,100,77,90], 3, [100,93,90] },
            { [84,93,100,77,93], 3, [100,93,84] },
            { [1,1,1,2,2,2], 3, [2,1] },
        };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int k, int[] expected)
    {
        var result = MaxKDistinct(nums, k);
        Assert.Equal(expected, result);
    }
}

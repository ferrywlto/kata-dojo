public class Q2903_FindIndicesWithIndexAndValueDifferenceI
{
    // TC: O(n^2), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
    {
        for (var i = 0; i < nums.Length - indexDifference; i++)
        {
            for (var j = i + indexDifference; j < nums.Length; j++)
            {
                if (Math.Abs(nums[i] - nums[j]) >= valueDifference)
                {
                    return [i, j];
                }
            }
        }
        return [-1, -1];
    }
    public static TheoryData<int[], int, int, int[]> TestData => new()
    {
        {[5,1,4,1], 2, 4, [0,3]},
        {[2,1], 0, 0, [0,0]},
        {[1,2,3], 2, 4, [-1,-1]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int idxDiff, int valDiff, int[] expected)
    {
        var actual = FindIndices(input, idxDiff, valDiff);
        Assert.Equal(expected, actual);
    }
}
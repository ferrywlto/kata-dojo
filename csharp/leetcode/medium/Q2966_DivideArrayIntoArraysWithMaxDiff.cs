public class Q2966_DivideArrayIntoArraysWithMaxDiff
{
    // TC: O(n log n), dominated by Array.Sort()
    // SC: O(n), n scale with length of nums to store the result
    public int[][] DivideArray(int[] nums, int k)
    {
        Array.Sort(nums);
        var result = new int[nums.Length / 3][];

        var resultIdx = 0;
        for (var i = 0; i < nums.Length - 2; i += 3)
        {
            if (nums[i + 2] - nums[i] > k) return [];

            result[resultIdx++] = [nums[i], nums[i + 1], nums[i + 2]];
        }
        return result;
    }
    public static TheoryData<int[], int, int[][]> TestData => new()
    {
        {[1,3,4,8,7,9,3,5,1], 2, [[1,1,3],[3,4,5],[7,8,9]]},
        {[2,4,2,2,5,2], 2, []},
        {[4,2,9,8,2,12,7,12,10,5,8,5,5,7,9,2,5,11], 14, [[2,2,2],[4,5,5],[5,5,7],[7,8,8],[9,9,10],[11,12,12]]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int[][] expected)
    {
        var actual = DivideArray(input, k);
        Assert.Equal(expected, actual);
    }
}

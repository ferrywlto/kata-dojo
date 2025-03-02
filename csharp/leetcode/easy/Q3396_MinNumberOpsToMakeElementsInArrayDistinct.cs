public class Q3396_MinNumberOpsToMakeElementsInArrayDistinct
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int MinimumOperations(int[] nums)
    {
        var lastExistIdx = new Dictionary<int, int>();
        var lastDupIdx = -1;
        var len = nums.Length;

        for (var i = 0; i < len; i++)
        {
            if (lastExistIdx.TryGetValue(nums[i], out var val))
            {
                if (val > lastDupIdx) lastDupIdx = val;
                lastExistIdx[nums[i]] = i;
            }
            else lastExistIdx.Add(nums[i], i);
        }
        return lastDupIdx == -1 ? 0 : lastDupIdx / 3 + 1;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3, 4,2,3, 3,5,7], 2},
        {[2,1,2, 2,1,2, 1,2,3, 4], 2},
        {[2,7,15,1,15], 1},
        {[4,5,6, 4,4], 2},
        {[4,5,6, 4,3], 1},
        {[6,7,8,9], 0},
        {[5,10,10], 1},
        {[2,2,2,2,2], 2},
        {[2,2,2,2,2,2], 2},
        {[2,2,2,2,2,1], 2},
        {[2,2,2,2,2,2,1], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}
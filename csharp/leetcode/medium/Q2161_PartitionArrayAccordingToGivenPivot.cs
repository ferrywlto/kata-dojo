public class Q2161_PartitionArrayAccordingToGivenPivot
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), the three queues take at most n space
    public int[] PivotArray(int[] nums, int pivot)
    {
        var len = nums.Length;
        var ans = new int[len];
        for (var i = 0; i < len; i++) ans[i] = pivot;

        var idx = 0;
        for (var i = 0; i < len; i++)
        {
            if (nums[i] < pivot) ans[idx++] = nums[i];
        }
        idx = len - 1;
        for (var i = len - 1; i >= 0; i--)
        {
            if (nums[i] > pivot) ans[idx--] = nums[i];
        }

        return ans;
    }
    public static TheoryData<int[], int, int[]> TestData => new()
    {
        {[9,12,5,10,14,3,10], 10, [9,5,3,10,10,12,14]},
        {[-3,4,3,2], 2, [-3,2,4,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int input2, int[] expected)
    {
        var actual = PivotArray(input1, input2);
        Assert.Equal(expected, actual);
    }
}
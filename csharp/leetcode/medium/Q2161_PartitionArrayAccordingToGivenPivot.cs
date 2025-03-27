public class Q2161_PartitionArrayAccordingToGivenPivot
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), the three queues take at most n space
    public int[] PivotArray(int[] nums, int pivot)
    {
        var lessThan = new List<int>();
        var largerThan = new List<int>();
        var equals = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > pivot)
                largerThan.Add(nums[i]);

            else if (nums[i] < pivot)
                lessThan.Add(nums[i]);

            else equals.Add(nums[i]);
        }

        lessThan.AddRange(equals);
        lessThan.AddRange(largerThan);
        return lessThan.ToArray();
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
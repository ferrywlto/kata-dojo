public class Q2161_PartitionArrayAccordingToGivenPivot
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), the three queues take at most n space
    public int[] PivotArray(int[] nums, int pivot)
    {
        var lessThan = new Queue<int>();
        var largerThan = new Queue<int>();
        var equals = new Queue<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > pivot)
                largerThan.Enqueue(nums[i]);

            else if (nums[i] < pivot)
                lessThan.Enqueue(nums[i]);

            else equals.Enqueue(nums[i]);
        }

        var idx = 0;
        while (lessThan.Count > 0)
            nums[idx++] = lessThan.Dequeue();

        while (equals.Count > 0)
            nums[idx++] = equals.Dequeue();

        while (largerThan.Count > 0)
            nums[idx++] = largerThan.Dequeue();

        return nums;
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
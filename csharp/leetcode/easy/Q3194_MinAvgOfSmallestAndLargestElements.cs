public class Q3194_MinAvgOfSmallestAndLargestElements
{
    // TC: O(n log n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public double MinimumAverage(int[] nums)
    {
        double result = int.MaxValue;
        Array.Sort(nums);
        for (var i = 0; i < nums.Length / 2; i++)
        {
            var start = nums[i];
            var end = nums[^(i + 1)];
            var avg = (start + end) / (double)2;
            if (avg < result) result = avg;
        }
        return result;
    }
    public static TheoryData<int[], double> TestData => new()
    {
        {[7,8,3,4,15,13,4,1], 5.5},
        {[1,9,8,3,10,5], 5.5},
        {[1,2,3,7,8,9], 5.0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, double expected)
    {
        var actual = MinimumAverage(input);
        Assert.Equal(expected, actual);
    }
}

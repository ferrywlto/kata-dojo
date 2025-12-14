public class Q3774_AbsoluteDiffBetweenMaxAndMinKElements
{
    // TC: O(n log n), dominated by Array.Sort()
    // SC: O(1), space used does not scale with input.
    public int AbsDifference(int[] nums, int k)
    {
        Array.Sort(nums);
        var min = 0;
        var max = 0;
        for (var i = 0; i < k; i++)
        {
            min += nums[i];
            max += nums[nums.Length - i - 1];
        }
        return Math.Abs(max - min);
    }

    public static TheoryData<int[], int, int> TestData = new TheoryData<int[], int, int>() {
        {[5,2,2,4], 2, 5},
        {[100], 1, 0},
    };
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = AbsDifference(input, k);
        Assert.Equal(expected, actual);
    }

}

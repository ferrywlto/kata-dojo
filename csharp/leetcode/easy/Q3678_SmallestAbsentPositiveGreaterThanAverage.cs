public class Q3678_SmallestAbsentPositiveGreaterThanAverage
{
    // TC: O(n), n scale with nums.Length
    // SC: O(1), counts size is fixed
    public int SmallestAbsent(int[] nums)
    {
        var counts = new int[101];
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0 && nums[i] <= 100)
            {
                counts[nums[i]]++;
            }
            sum += nums[i];
        }
        var avg = sum / (double)nums.Length;

        for (var i = 1; i <= 100; i++)
        {
            if (counts[i] == 0 && i > avg)
            {
                return i;
            }
        }
        return 101;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,5], 6},
        {[-1,1,2], 3},
        {[4,-1], 2},
        {[98,100], 101},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var actual = SmallestAbsent(nums);
        Assert.Equal(expected, actual);
    }
}

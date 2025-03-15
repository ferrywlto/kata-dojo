public class Q2970_CountNumberOfIncremovableSubarraysI
{
    // TC: O(n^3), n scale with length of nums
    // SC: O(n), temp is the same size as input
    public int IncremovableSubarrayCount(int[] nums)
    {
        var result = 0;
        // expansion
        for (var i = 0; i < nums.Length; i++)
        {
            var temp = new int[nums.Length];
            Array.Copy(nums, temp, nums.Length);
            for (var j = i; j < nums.Length; j++)
            {
                temp[j] = 0;
                if (Incresing(temp)) result++;
            }
        }
        return result;
    }
    private bool Incresing(int[] input)
    {
        var lastNonZeroIdx = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] > 0)
            {
                lastNonZeroIdx = i;
                break;
            }
        }
        for (var i = lastNonZeroIdx + 1; i < input.Length; i++)
        {
            if (input[i] > 0 && input[i] <= input[lastNonZeroIdx]) return false;
            else if (input[i] > 0)
            {
                lastNonZeroIdx = i;
            }
        }
        return true;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4], 10},
        {[6,5,7,8], 7},
        {[8,7,6,6], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = IncremovableSubarrayCount(input);
        Assert.Equal(expected, actual);
    }
}
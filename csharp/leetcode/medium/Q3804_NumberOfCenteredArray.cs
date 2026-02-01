public class Q3804_NumberOfCanteredArray
{
    // TC: O(n^2)
    // SC: O(n), worst case set contains all elements (first run)
    public int CenteredSubarrays(int[] nums)
    {
        var result = 0;
        var set = new HashSet<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            // single element must include
            result++;
            set.Clear();
            set.Add(nums[i]);
            var sum = nums[i];

            for (var j = i + 1; j < nums.Length; j++)
            {
                set.Add(nums[j]);
                sum += nums[j];
                if (set.Contains(sum)) result++;
            }
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[-1,1,0], 5},
        {[2,-3], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CenteredSubarrays(input);
        Assert.Equal(expected, actual);
    }
}

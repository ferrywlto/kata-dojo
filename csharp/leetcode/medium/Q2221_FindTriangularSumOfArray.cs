public class Q2221_FindTriangularSumOfArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(1)
    public int TriangularSum(int[] nums)
    {
        var len = nums.Length;
        while (len != 1)
        {
            for (var i = 0; i < len - 1; i++)
            {
                nums[i] = (nums[i] + nums[i + 1]) % 10;
            }
            len--;
        }
        return nums[0];
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4,5], 8},
        {[5], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = TriangularSum(input);
        Assert.Equal(expected, actual);
    }
}

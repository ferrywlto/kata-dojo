public class Q2778_SumOfSquaresOfSpecialElements
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int SumOfSquares(int[] nums)
    {
        var result = 0;
        var len = nums.Length;
        for (var i = 0; i < len; i++)
        {
            var idx = i + 1;
            if (len % idx == 0)
            {
                result += nums[i] * nums[i];
            }
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4], 21},
        {[2,7,1,19,18,3], 63},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SumOfSquares(input);
        Assert.Equal(expected, actual);
    }
}

public class Q2367_NumArithmeticTriplets
{
    // TC: O(n^3), n scale with length of nums
    // SC: O(1), space used does not scale with input 
    public int ArithmeticTriplets(int[] nums, int diff)
    {
        var result = 0;
        for (var k = nums.Length - 1; k >= 2; k--)
        {
            for (var j = k - 1; j >= 1; j--)
            {
                for (var i = j - 1; i >= 0; i--)
                {
                    if (nums[k] - nums[j] == diff && nums[j] - nums[i] == diff)
                    {
                        result++;
                    }
                }
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {0,1,4,6,7,10}, 3, 2],
        [new int[] {4,5,6,7,8,9}, 2, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int diff, int expected)
    {
        var actual = ArithmeticTriplets(input, diff);
        Assert.Equal(expected, actual);
    }
}
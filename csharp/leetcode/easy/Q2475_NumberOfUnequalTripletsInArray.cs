public class Q2475_NumberOfUnequalTripletsInArray
{
    // TC: O(n^3), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int UnequalTriplets(int[] nums)
    {
        var count = 0;
        for (var i = 0; i < nums.Length - 2; i++)
        {
            for (var j = i + 1; j < nums.Length - 1; j++)
            {
                for (var k = j + 1; k < nums.Length; k++)
                {
                    if (nums[i] != nums[j]
                    && nums[j] != nums[k]
                    && nums[k] != nums[i]) count++;
                }
            }
        }
        return count;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,4,2,4,3}, 3],
        [new int[] {1,1,1,1,1}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = UnequalTriplets(input);
        Assert.Equal(expected, actual);
    }
}

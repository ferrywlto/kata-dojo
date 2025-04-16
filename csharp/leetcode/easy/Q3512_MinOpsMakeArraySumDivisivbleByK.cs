public class Q3512_MinOpsMakeArraySumDivisivbleByK
{
    // TC: O(n), n scale with lenght of nums
    // SC: O(1), space used does not scale with input
    public int MinOperations(int[] nums, int k)
    {
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        var remainer = sum % k;
        return remainer;
    }
    public static TheoryData<int[], int, int> TestData = new()
    {
        {[3,9,7], 5, 4},
        {[4,1,3], 4, 0},
        {[3,2], 6, 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}
public class Q3314_ConstructMinBitwiseArrayI
{
    // TC: O(n^2), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int[] MinBitwiseArray(IList<int> nums)
    {
        for (var i = 0; i < nums.Count; i++)
        {
            nums[i] = Break(nums[i]);
        }
        return nums.ToArray();
    }
    private int Break(int input)
    {
        for (var i = 0; i < input; i++)
        {
            if ((i | (i + 1)) == input)
            {
                return i;
            }
        }
        return -1;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[2,3,5,7], [-1,1,4,3]},
        {[11,13,31], [9,12,15]},
        {[1000,999,998], [9,12,15]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinBitwiseArray(input);
        Assert.Equal(expected, actual);
    }
}
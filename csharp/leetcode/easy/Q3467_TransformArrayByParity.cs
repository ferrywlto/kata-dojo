public class Q3467_TransformArrayByParity
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), same as time
    public int[] TransformArray(int[] nums)
    {
        var result = new int[nums.Length];
        var idx = nums.Length - 1;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 != 0)
            {
                result[idx] = 1;
                idx--;
            }
        }
        return result;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[4,3,2,1], [0,0,1,1]},
        {[1,5,1,4,2], [0,0,1,1,1]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = TransformArray(input);
        Assert.Equal(expected, actual);
    }
}

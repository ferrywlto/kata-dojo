public class Q2149_RearrangeArrayElementsBySign
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), to hold the result
    public int[] RearrangeArray(int[] nums)
    {
        var result = new int[nums.Length];
        var positiveIdx = 0;
        var negativeIndex = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= 0)
            {
                result[positiveIdx] = nums[i];
                positiveIdx += 2;
            }
            else
            {
                result[negativeIndex] = nums[i];
                negativeIndex += 2;
            }
        }
        return result;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[3,1,-2,-5,2,-4], [3,-2,1,-5,2,-4]},
        {[-1,1], [1,-1]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = RearrangeArray(input);
        Assert.Equal(expected, actual);
    }
}

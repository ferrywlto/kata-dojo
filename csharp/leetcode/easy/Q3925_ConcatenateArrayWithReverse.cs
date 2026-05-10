public class Q3925_ConcatenateArrayWithReverse
{
    // TC: O(n)
    // SC: O(n)
    public int[] ConcatWithReverse(int[] nums)
    {
        var len = nums.Length;
        var result = new int[len * 2];
        for (var i = 0; i < len; i++)
        {
            result[i] = nums[i];
            result[i + len] = nums[len - 1 - i];
        }
        return result;
    }

    public static TheoryData<int[], int[]> TestData = new()
    {
        { [1, 2, 3], [1, 2, 3, 3, 2, 1] },
        { [1], [1, 1] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = ConcatWithReverse(input);
        Assert.Equal(expected, actual);
    }
}

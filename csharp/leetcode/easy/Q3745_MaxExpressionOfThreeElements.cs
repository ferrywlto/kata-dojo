public class Q3745_MaxExpressionOfThreeElements
{
    public int MaximizeExpressionOfThree(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        { [1,4,2,5], 8},
        { [-2,0,5,-2,4], 11},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var result = MaximizeExpressionOfThree(nums);
        Assert.Equal(expected, result);
    }
}

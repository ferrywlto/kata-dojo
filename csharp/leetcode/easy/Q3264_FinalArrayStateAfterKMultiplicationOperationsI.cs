public class Q3264_FinalArrayStateAfterKMultiplicationOperationsI
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        return [];
    }
    public static TheoryData<int[], int, int, int[]> TestData => new()
    {
        {[2,1,3,5,6], 5, 2, [8,4,6,5,6]},
        {[1,2], 3, 4, [16,8]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int m, int[] expected)
    {
        var actual = GetFinalState(input, k, m);
        Assert.Equal(expected, actual);
    }
}
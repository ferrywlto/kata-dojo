public class Q2778_SumOfSquaresOfSpecialElements
{
    public int SumOfSquares(int[] nums)
    {
        return 0;
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
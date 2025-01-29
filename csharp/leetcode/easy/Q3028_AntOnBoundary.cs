public class Q3028_AntOnBoundary
{
    public int ReturnToBoundaryCount(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,3,-5], 1},
        {[3,2,-3,-4], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = ReturnToBoundaryCount(input);
        Assert.Equal(expected, actual);
    }
}
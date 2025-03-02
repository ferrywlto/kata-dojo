public class Q3396_MinNumberOpsToMakeElementsInArrayDistinct
{
    public int MinimumOperations(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4,2,3,3,5,7], 2},
        {[4,5,6,4,4], 2},
        {[6,7,8,9], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}
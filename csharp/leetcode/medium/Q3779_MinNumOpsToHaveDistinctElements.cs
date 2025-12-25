public class Q3779_MinNumOpsToHaveDistinctElements
{
    public int MinOperations(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,8,3,6,5,8], 1},
        {[2,2], 1},
        {[4,3,5,1,2], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

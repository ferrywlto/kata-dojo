public class Q2869_MinOperationsToCollectElements
{
    public int MinOperations(IList<int> nums, int k)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[3,1,5,4,2], 2, 4},
        {[3,1,5,4,2], 5, 5},
        {[3,2,5,3,1], 3, 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}
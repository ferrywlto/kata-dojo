public class Q3375_MinOpsMakeArrayValuesEqualK
{
    public int MinOperations(int[] nums, int k)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[5,2,5,4,5], 2, 2},
        {[2,1,2], 2, -1},
        {[9,7,5,3], 1, 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}
public class Q3833_CountDominantIndices
{
    public int DominantIndices(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[5,4,3], 2},
        {[4,1,2], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = DominantIndices(input);
        Assert.Equal(expected, actual);
    }
}

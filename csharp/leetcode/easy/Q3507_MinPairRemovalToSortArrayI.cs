public class Q3507_MinPairRemovalToSortArrayI
{
    public int MinimumPairRemoval(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[5,2,3,1], 2},
        {[1,2,2], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumPairRemoval(input);
        Assert.Equal(expected, actual);
    }
}
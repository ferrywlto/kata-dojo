public class Q78_Subsets
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], IList<IList<int>>> TestData => new()
    {
        {[1,2,3], [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]},
        {[0], [[],[0]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, IList<IList<int>> expected)
    {
        var actual = Subsets(input);
        Assert.Equal(expected, actual);
    }
}

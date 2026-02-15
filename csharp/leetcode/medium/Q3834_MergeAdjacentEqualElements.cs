public class Q3834_MergeAdjacentEqualElements
{
    public IList<long> MergeAdjacent(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], List<long>> TestData => new()
    {
        {[3,1,1,2], [3,4]},
        {[2,2,4], [8]},
        {[3,7,5], [3,7,5]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<long> expected)
    {
        var actual = MergeAdjacent(input);
        Assert.Equal(expected, actual);
    }
}

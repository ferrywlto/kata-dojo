public class Q3731_FindMissingElements
{
    public IList<int> FindMissingElements(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], IList<int>> TestData => new()
    {
        {[1,4,2,5], [3]},
        {[7,8,6,9], []},
        {[5,1], [2,3,4]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, IList<int> expected)
    {
        var result = FindMissingElements(input);
        Assert.Equal(expected, result);
    }
}

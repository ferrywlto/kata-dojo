public class Q46_Permutatiuons
{
    public IList<IList<int>> Permute(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], IList<IList<int>> TestData => new()
    {
        {[1,2,3], [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]},
        {[0,1], [[0,1],[1,0]]},
        {[1], [[1]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, IList<IList<int>> expected)
    {
        var actual = Permute(input);
        Assert.Equal(expected, actual);
    }
}

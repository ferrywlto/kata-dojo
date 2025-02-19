public class Q3285_FindIndicesOfStableMountains
{
    public IList<int> StableMountains(int[] height, int threshold)
    {
        return [];
    }
    public static TheoryData<int[], int, List<int>> TestData => new()
    {
        {[1,2,3,4,5], 2, [3,4]},
        {[10,1,10,1,10], 3, [1,3]},
        {[10,1,10,1,10], 10, []},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int t, List<int> expected)
    {
        var actual = StableMountains(input, t);
        Assert.Equal(expected, actual);
    }
}
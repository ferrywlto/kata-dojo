public class Q2951_FindThePeaks
{
    public IList<int> FindPeaks(int[] mountain)
    {
        return [];
    }
    public static TheoryData<int[], List<int>> TestData => new()
    {
        {[2,4,4], []},
        {[1,4,3,8,5], [1,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<int> expected)
    {
        var actual = FindPeaks(input);
        Assert.Equal(expected, actual);
    }
}
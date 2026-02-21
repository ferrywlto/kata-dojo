public class Q3842_ToggleLightBulbs
{
    public IList<int> ToggleLightBulbs(IList<int> bulbs)
    {
        return [];
    }
    public static TheoryData<List<int>, List<int>> TestData => new()
    {
        {[10,30,20,10], [20,30]},
        {[100,100], []},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(List<int> input, List<int> expected)
    {
        var actual = ToggleLightBulbs(input);
        Assert.Equal(expected, actual);
    }
}

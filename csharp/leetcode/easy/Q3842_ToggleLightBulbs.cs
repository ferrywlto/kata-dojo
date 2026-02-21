public class Q3842_ToggleLightBulbs
{
    // TC: O(n), n scale with length of bulbs
    // SC: O(n), for storing result, otherwise O(1)
    public IList<int> ToggleLightBulbs(IList<int> bulbs)
    {
        Span<int> b = stackalloc int[101];
        foreach (var n in bulbs)
        {
            if (b[n] == 0) b[n] = 1;
            else b[n] = 0;
        }
        var result = new List<int>();
        for (var i = 0; i < b.Length; i++)
        {
            if (b[i] == 1) result.Add(i);
        }
        return result;
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

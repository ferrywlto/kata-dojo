public class Q2951_FindThePeaks
{
    // TC: O(n), n scale with length of mountain
    // SC: O(n), to hold the result, if not counting it then O(1)
    public IList<int> FindPeaks(int[] mountain)
    {
        var result = new List<int>();
        for (var i = 1; i < mountain.Length - 1; i++)
        {
            if (mountain[i] > mountain[i - 1] && mountain[i] > mountain[i + 1])
            {
                result.Add(i);
            }
        }
        return result;
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

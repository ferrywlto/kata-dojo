class Q1051_HeightCHecker
{
    // TC:O(n log n), n is length of heights, n log n caused by Array.Sort()
    // SC:O(n), as need ot copy heights
    public int HeightChecker(int[] heights)
    {
        int[] clone = new int[heights.Length];
        Array.Copy(heights, clone, heights.Length);
        Array.Sort(clone);

        var count = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            if (heights[i] != clone[i]) count++;
        }
        return count;
    }
}
class Q1051_HeightCHeckerTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,1,4,2,1,3}, 3],
        [new int[]{5,1,2,3,4}, 5],
        [new int[]{1,2,3,4,5}, 0],
    ];
}
public class Q1051_HeightCHeckerTests
{
    [Theory]
    [ClassData(typeof(Q1051_HeightCHeckerTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1051_HeightCHecker();
        var actual = sut.HeightChecker(input);
        Assert.Equal(expected, actual);
    }
}
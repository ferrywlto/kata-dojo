public class Q3285_FindIndicesOfStableMountains
{
    // TC: O(n), n scale with length of height
    // SC: O(m), m sacle with number of stable mountains to hold the result, if not count it is O(1)
    public IList<int> StableMountains(int[] height, int threshold)
    {
        var result = new List<int>();
        for (var i = 1; i < height.Length; i++)
        {
            if (height[i - 1] > threshold) result.Add(i);
        }
        return result;
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

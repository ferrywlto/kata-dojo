public class Q3852_SmallestPairWithDifferentFrequencies
{
    public int[] MinDistinctFreqPair(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[1,1,2,2,3,4], [1,3]},
        {[1,5], [-1,-1]},
        {[7], [-1, -1]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinDistinctFreqPair(input);
        Assert.Equal(expected, actual);
    }
}

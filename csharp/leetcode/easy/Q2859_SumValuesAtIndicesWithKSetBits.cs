public class Q2859_SumValuesAtIndicesWithKSetBits
{
    public int SumIndicesWithKSetBits(IList<int> nums, int k)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[5,10,1,5,2], 1, 13},
        {[4,3,2,1], 2, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = SumIndicesWithKSetBits(input, k);
        Assert.Equal(expected, actual);
    }
}
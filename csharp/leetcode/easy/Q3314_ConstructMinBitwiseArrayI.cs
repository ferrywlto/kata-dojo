public class Q3314_ConstructMinBitwiseArrayI
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[2,3,5,7], [-1,1,4,3]},
        {[211,13,31], [9,12,15]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinBitwiseArray(input);
        Assert.Equal(expected, actual);
    }
}
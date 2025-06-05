public class Q3550_SmallestIndexWithDigitSumEqualToIndex
{
    public int SmallestIndex(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,3,2], 2},
        {[1,10,11], 1},
        {[1,2,3], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SmallestIndex(input);
        Assert.Equal(expected, actual);
    }
}
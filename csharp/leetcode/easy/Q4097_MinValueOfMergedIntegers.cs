public class Q4097_MinValueOfMergedIntegers
{
    public int MinMergedInteger(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [23, 55, 42, 21], 2355 },
        { [34, 7, 11, 11], 347 },
        { [9, 20], 920 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinMergedInteger(input);
        Assert.Equal(expected, actual);
    }
}

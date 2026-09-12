public class Q4048_CountValuesWithEquallySpacedOccurrencesI
{
    public int CountSpecialIntegers(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 8, 1, 5, 1, 5, 8, 5], 2 },
        { [8, 8, 8, 8], 0 },
        { [8, 8, 6, 6, 8], 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountSpecialIntegers(input);
        Assert.Equal(expected, actual);
    }
}

public class Q3895_CountDigitAppeasrances
{
    public int CountDigitOccurrences(int[] nums, int digit)
    {
        return 0;
    }

    public static TheoryData<int[], int, int> TestData => new() { { [12, 54, 32, 22], 2, 4 }, { [1, 34, 7], 9, 0 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int digit, int expected)
    {
        var actual = CountDigitOccurrences(input, digit);
        Assert.Equal(expected, actual);
    }
}

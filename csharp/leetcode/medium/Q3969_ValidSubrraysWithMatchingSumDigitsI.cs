public class Q3969_ValidSubarraysWithMatchingSumDigitsI
{
    public int CountValidSubarrays(int[] nums, int x)
    {
        return 0;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1, 100, 1], 1, 4 },
        { [1], 2, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = CountValidSubarrays(input, k);
        Assert.Equal(expected, actual);
    }
}

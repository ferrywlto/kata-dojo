public class Q3940_LimitOccurenceInSortedArray
{
    public int[] LimitOccurrences(int[] nums, int k)
    {
        return [];
    }

    public static TheoryData<int[], int, int[]> TestData => new()
    {
        { [1, 1, 1, 2, 2, 3], 2, [1, 1, 2, 2, 3] },
        { [1, 2, 3], 1, [1, 2, 3] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int[] expected)
    {
        var actual = LimitOccurrences(input, k);
        Assert.Equal(expected, actual);
    }
}

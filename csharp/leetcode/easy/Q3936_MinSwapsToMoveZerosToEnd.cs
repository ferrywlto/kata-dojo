public class Q3936_MinSwapsToMoveZerosToEnd
{
    public int MinimumSwaps(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [0, 1, 0, 3, 12], 2 },
        { [0, 1, 0, 2], 1 },
        { [1, 2, 0], 0 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumSwaps(input);
        Assert.Equal(expected, actual);
    }
}

public class Q3914_MinOpsToMakeArrayNonDecreasing
{
    public long MinOperations(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData = new()
    {
        { [3, 3, 2, 1], 2 },
        { [5, 1, 2, 3], 4 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

public class Q3674_MinOpsToEqualizeArray
{
    public int MinOperations(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new() { { [1, 2], 1 }, { [5, 5, 5], 1 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

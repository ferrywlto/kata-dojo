public class Q3937_MinOpsToMakeArrayModuleAlternatingI
{
    public int MinOperations(int[] nums, int k)
    {
        return 0;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1, 4, 2, 8], 3, 2 },
        { [1, 1, 1], 3, 1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}

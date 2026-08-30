public class Q4040_MinOpsToFormSubsetSumI
{
    public int MinOperations(int[] nums, int sum)
    {
        return 0;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [5, 6, 10], 4, 3 },
        { [10, 2], 13, 3 },
        { [6, 3], 8, -1 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int sum, int expected)
    {
        var actual = MinOperations(nums, sum);
        Assert.Equal(expected, actual);
    }
}

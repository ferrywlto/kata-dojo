public class Q3877_MinRemovalsToAchiveTargetXor
{
    public int MinRemovals(int[] nums, int target)
    {
        return 0;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1, 2, 3], 2, 1 }, { [2, 4], 2, 1 }, { [7], 1, -1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int target, int expected)
    {
        var actual = MinRemovals(input, target);
        Assert.Equal(expected, actual);
    }
}

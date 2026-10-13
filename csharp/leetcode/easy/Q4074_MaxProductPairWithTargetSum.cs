public class Q4074_MaxProductPairWithTargetSum
{
    public int[] MaxProductPair(int[] nums, int target)
    {
        return [];
    }

    public static TheoryData<int[], int, int[]> TestData => new()
    {
        { [1, 2, 3, 4], 5, [2, 1] },
        { [-3, -1, 4, 2], 1, [3, 1] },
        { [3, 3, 5], 6, [-1, -1] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int target, int[] expected)
    {
        var actual = MaxProductPair(input, target);
        Assert.Equal(expected, actual);
    }
}

public class Q2529_MaxCountOfPositiveIntegerAndNegativeInteger
{
    public int MaximumCount(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {-2,-1,-1,1,2,3}, 3],
        [new int[] {-2,-1,-1,1,2,3}, 3],
        [new int[] {-2,-1,-1,1,2,3}, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumCount(input);
        Assert.Equal(expected, actual);
    }
}

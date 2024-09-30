public class Q2006_CountNumberOfPairsWithAbsoluteDifference
{
    public int CountKDifference(int[] nums, int k)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,2,1}, 1, 4],
        [new int[] {1,3}, 3, 0],
        [new int[] {3,2,1,5,4}, 2, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = CountKDifference(input, k);
        Assert.Equal(expected, actual);
    }
}
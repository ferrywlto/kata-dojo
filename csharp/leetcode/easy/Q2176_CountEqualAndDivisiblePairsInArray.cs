public class Q2176_CountEqualAndDivisiblePairsInArray
{
    public int CountPairs(int[] nums, int k)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {3,1,2,2,2,1,3}, 2, 4],
        [new int[] {1,2,3,4}, 2, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = CountPairs(input, k);
        Assert.Equal(expected, actual);
    }
}
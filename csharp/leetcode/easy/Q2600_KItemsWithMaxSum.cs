public class Q2600_KItemsWithMaxSum
{
    public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [3, 2, 0, 2, 2],
        [3, 2, 0, 4, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int ones, int zeros, int negs, int k, int expected)
    {
        var actual = KItemsWithMaximumSum(ones, zeros, negs, k);
        Assert.Equal(expected, actual);
    }
}

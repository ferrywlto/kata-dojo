public class Q2600_KItemsWithMaxSum
{
    // TC: O(1) obviously
    // SC: O(1) same as time
    public int KItemsWithMaximumSum(int numOnes, int numZeros, int _, int k)
    {
        var result = 0;
        if (numOnes >= k) return k;
        else
        {
            result += numOnes;
            k -= numOnes;
            if (numZeros >= k) return result;
            else
            {
                k -= numZeros;
                return result + (k * -1);
            }
        }
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

public class Q2894_DivisibleAndNonDivisibleSumsDifference
{
    // TC: O(n), n scale with size of n
    // SC: O(1), space used does not scale with input
    public int DifferenceOfSums(int n, int m)
    {
        var num1 = 0;
        var num2 = 0;
        for (var i = 1; i <= n; i++)
        {
            if (i % m == 0) num2 += i;
            else num1 += i;
        }
        return num1 - num2;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {10, 3, 19},
        {5, 6, 15},
        {5, 1, -15},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int m, int expected)
    {
        var actual = DifferenceOfSums(n, m);
        Assert.Equal(expected, actual);
    }
}

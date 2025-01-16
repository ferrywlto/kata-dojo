public class Q2894_DivisibleAndNonDivisibleSumsDifference
{
    public int DifferenceOfSums(int n, int m)
    {
        return 0;
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
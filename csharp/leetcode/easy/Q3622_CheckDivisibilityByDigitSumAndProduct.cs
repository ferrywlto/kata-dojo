public class Q3622_CheckDivisibilityByDigitSumAndProduct
{
    public bool CheckDivisibility(int n)
    {
        return false;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        { 99, true},
        { 23, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, bool expected)
    {
        var actual = CheckDivisibility(n);
        Assert.Equal(expected, actual);
    }
}
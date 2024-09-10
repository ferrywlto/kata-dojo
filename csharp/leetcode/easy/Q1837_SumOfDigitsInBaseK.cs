class Q1837_SumOfDigitsInBaseK
{
    // TC: O(log_k n), as n will keep smaller by k factor each operation
    // SC: O(1), space used if fixed
    public int SumBase(int n, int k)
    {
        var result = 0;
        while (n > 0)
        {
            result += n % k;
            n /= k;
        }
        return result;
    }
}
class Q1837_SumOfDigitsInBaseKTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [34, 6, 9],
        [10, 10, 1],
    ];
}
public class Q1837_SumOfDigitsInBaseKTests
{
    [Theory]
    [ClassData(typeof(Q1837_SumOfDigitsInBaseKTestData))]
    public void OfficialTestCases(int input, int k, int expected)
    {
        var sut = new Q1837_SumOfDigitsInBaseK();
        var actual = sut.SumBase(input, k);
        Assert.Equal(expected, actual);
    }
}
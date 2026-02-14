class Q1281_SubtractProductAndSum
{
    // TC: O(n), n is the size of n
    // SC: O(1), no space used in calculation
    public int SubtractProductAndSum(int n)
    {
        int sum;
        int product;
        if (n == 0) return 0;

        var mod = n % 10;
        sum = mod;
        product = mod;
        n /= 10;
        while (n > 0)
        {
            mod = n % 10;
            sum += mod;
            product *= mod;
            n /= 10;
        }
        return product - sum;
    }
}
class Q1281_SubtractProductAndSumTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [234, 15],
        [4421, 21],
    ];
}
public class Q1281_SubtractProductAndSumTests
{
    [Theory]
    [ClassData(typeof(Q1281_SubtractProductAndSumTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1281_SubtractProductAndSum();
        var actual = sut.SubtractProductAndSum(input);
        Assert.Equal(expected, actual);
    }
}

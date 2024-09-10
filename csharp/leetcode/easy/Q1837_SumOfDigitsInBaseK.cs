class Q1837_SumOfDigitsInBaseK
{
    public int SumBase(int n, int k)
    {
        return 0;
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
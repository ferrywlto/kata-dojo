class Q1317_ConvertIntegerToSumOfTwoNonZeroIntegers
{
    public int[] GetNoZeroIntegers(int n)
    {
        return [];
    }
}
class Q1317_ConvertIntegerToSumOfTwoNonZeroIntegersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [2, new int[2]{1,1}],
        [11, new int[2]{2,9}],
    ];
}
public class Q1317_ConvertIntegerToSumOfTwoNonZeroIntegersTests
{
    [Theory]
    [ClassData(typeof(Q1317_ConvertIntegerToSumOfTwoNonZeroIntegersTestData))]
    public void OfficialTestCases(int input, int[] expected)
    {
        var sut = new Q1317_ConvertIntegerToSumOfTwoNonZeroIntegers();
        var actual = sut.GetNoZeroIntegers(input);
        Assert.Equal(expected, actual);
    }
}

class Q1281_SubtractProductAndSum
{
    public int SubtractProductAndSum(int n)
    {
        return 0;
    }
}
class Q1281_SubtractProductAndSumTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [234, 14],
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

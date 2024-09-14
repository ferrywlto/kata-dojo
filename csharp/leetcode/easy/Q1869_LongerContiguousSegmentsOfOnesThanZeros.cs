class Q1869_LongerContiguousSegmentsOfOnesThanZeros
{
    public bool CheckZeroOnes(string s)
    {
        return false;
    }
}
class Q1869_LongerContiguousSegmentsOfOnesThanZerosTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["1101", true],
        ["111000", false],
        ["110100010", false],
    ];
}
public class Q1869_LongerContiguousSegmentsOfOnesThanZerosTests
{
    [Theory]
    [ClassData(typeof(Q1869_LongerContiguousSegmentsOfOnesThanZerosTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1869_LongerContiguousSegmentsOfOnesThanZeros();
        var actual = sut.CheckZeroOnes(input);
        Assert.Equal(expected, actual);
    }
}
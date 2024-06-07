class Q1108_DefangingIPAddress
{
    public string DefangIPaddr(string address)
    {
        return string.Empty;
    }
}
class Q1108_DefangingIPAddressTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["1.1.1.1", "1[.]1[.]1[.]1"],
        ["255.100.50.0", "255[.]100[.]50[.]0"],
    ];
}
public class Q1108_DefangingIPAddressTests
{
    [Theory]
    [ClassData(typeof(Q1108_DefangingIPAddressTestData))]
    public void OfficicalTestCases(string input, string expected)
    {
        var sut = new Q1108_DefangingIPAddress();
        var actual = sut.DefangIPaddr(input);
        Assert.Equal(expected, actual);
    }
}
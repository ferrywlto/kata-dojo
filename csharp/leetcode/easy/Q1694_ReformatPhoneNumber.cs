
class Q1694_ReformatPhoneNumber
{
    public string ReformatNumber(string number) 
    {
        return string.Empty;    
    }    
}
class Q1694_ReformatPhoneNumberTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["1-23-45 6", "123-456"],
        ["123 4-567", "123-45-67"],
        ["123 4-5678", "123-456-78"],
    ];
}
public class Q1694_ReformatPhoneNumberTests
{
    [Theory]
    [ClassData(typeof(Q1694_ReformatPhoneNumberTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1694_ReformatPhoneNumber();
        var actual = sut.ReformatNumber(input);
        Assert.Equal(expected, actual);
    }
}
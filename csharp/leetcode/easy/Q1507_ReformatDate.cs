
class Q1507_ReformatDate
{
    public string ReformatDate(string date) 
    {
        return string.Empty;    
    }    
}
class Q1507_ReformatDateTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["20th Oct 2052", "2052-10-20"],
        ["6th Jun 1933", "1933-06-06"],
        ["26th May 1960", "1960-05-26"],
    ];
}
public class Q1507_ReformatDateTests
{
    [Theory]
    [ClassData(typeof(Q1507_ReformatDateTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1507_ReformatDate();
        var actual = sut.ReformatDate(input);
        Assert.Equal(expected, actual);
    }
}
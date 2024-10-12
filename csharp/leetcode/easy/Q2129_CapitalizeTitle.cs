public class Q2129_CapitalizeTitle
{
    public string CapitalizeTitle(string title) 
    {
        return string.Empty;   
    }
    public static List<object[]> TestData =>
    [
        ["capiTalIze tHe titLe", "Capitalize The Title"],
        ["First leTTeR of EACH Word", "First Letter of Each Word"],
        ["i lOve leetcode", "i Love Leetcode"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]    
    public void Test(string input, string expected)
    {
        var actual = CapitalizeTitle(input);
        Assert.Equal(expected, actual);
    }
}
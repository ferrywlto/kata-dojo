public class Q3823_ReverseLettersThenSpecialCharactersInString
{
    public string ReverseByType(string s)
    {
        return "";
    }
    public static TheoryData<string, string> TestData => new()
    {
        {")ebc#da@f(", "(fad@cb#e)"},
        {"z", "z"},
        {"!@#$%^&*()", ")(*&^%$#@!"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = ReverseByType(input);
        Assert.Equal(expected, actual);
    }
}

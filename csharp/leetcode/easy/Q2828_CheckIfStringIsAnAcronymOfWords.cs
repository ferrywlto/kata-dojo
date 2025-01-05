public class Q2828_CheckIfStringIsAnAcronymOfWords
{
    public bool IsAcronym(IList<string> words, string s)
    {
        return false;
    }
    public static TheoryData<string[], string, bool> TestData => new()
    {
        {["alice","bob","charlie"], "abc", true},
        {["an","apple"], "a", false},
        {["never","gonna","give","up","on","you"], "ngguoy", true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string s, bool expected)
    {
        var actual = IsAcronym(input, s);
        Assert.Equal(expected, actual);
    }
}
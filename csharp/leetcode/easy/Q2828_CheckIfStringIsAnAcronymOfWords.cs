public class Q2828_CheckIfStringIsAnAcronymOfWords
{
    // TC: O(n), n scale with length of words
    // SC: O(1), space used does not scale with input
    public bool IsAcronym(IList<string> words, string s)
    {
        var len = words.Count;
        if (len != s.Length) return false;
        for (var i = 0; i < words.Count; i++)
        {
            if (words[i][0] != s[i]) return false;
        }
        return true;
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
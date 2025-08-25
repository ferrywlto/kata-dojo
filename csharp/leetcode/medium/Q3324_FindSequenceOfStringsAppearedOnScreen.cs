public class Q3324_FindSequenceOfStringsAppearedOnScreen
{
    public IList<string> StringSequence(string target)
    {
        return [];
    }
    public static TheoryData<string, IList<string>> TestData => new()
    {
        {"abc", ["a","aa","ab","aba","abb","abc"]},
        {"he", ["a","b","c","d","e","f","g","h","ha","hb","hc","hd","he"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, IList<string> expected)
    {
        var actual = StringSequence(input);
        Assert.Equal(expected, actual);
    }
}

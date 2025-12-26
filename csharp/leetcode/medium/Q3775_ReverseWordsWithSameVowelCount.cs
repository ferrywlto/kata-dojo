public class Q3775_ReverseWordsWithSameVowelCount
{
    public string ReverseWords(string s)
    {
        return string.Empty;
    }

    public static TheoryData<string, string> TestData => new()
    {
        {"cat and mice", "cat dna mice"},
        {"book is nice", "book is ecin"},
        {"banana healthy", "banana healthy"},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = ReverseWords(input);
        Assert.Equal(expected, actual);
    }
}

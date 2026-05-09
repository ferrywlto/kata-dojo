public class Q3913_SortVowelsByFrequency
{
    public string SortVowels(string s)
    {
        return string.Empty;
    }

    public static TheoryData<string, string> TestData => new()
    {
        { "leetcode", "leetcedo" },
        { "aeiaaioooa", "aaaaoooiie" },
        { "baeiou", "baeiou" },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = SortVowels(input);
        Assert.Equal(expected, actual);
    }
}

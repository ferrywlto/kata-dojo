public class Q3853_MergeCloseCharacters
{
    public string MergeCharacters(string s, int k)
    {
        return "";
    }

    public static TheoryData<string, int, string> TestData => new()
    {
        { "abca", 3, "abc" }, { "aabca", 2, "abca" }, { "yybyzybz", 2, "ybzybz" },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = MergeCharacters(input, k);
        Assert.Equal(expected, actual);
    }
}

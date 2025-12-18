public class Q2390_RemovingStartsFromString
{
    public string RemoveStars(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"leet**cod*e", "lecoe"},
        {"erase*****", ""},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = RemoveStars(input);
        Assert.Equal(expected, actual);
    }
}

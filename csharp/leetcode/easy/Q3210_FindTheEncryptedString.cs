public class Q3210_FindTheEncryptedString
{
    public string GetEncryptedString(string s, int k)
    {
        return string.Empty;
    }
    public static TheoryData<string, int, string> TestData => new()
    {
        {"dart", 3, "tdar"},
        {"aaa", 1, "aaa"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = GetEncryptedString(input, k);
        Assert.Equal(expected, actual);
    }
}
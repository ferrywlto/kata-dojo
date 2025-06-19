public class Q3271_HashDividedString
{
    public string StringHash(string s, int k)
    {
        return "";
    }
    public static TheoryData<string, int, string> TestData => new()
    {
        {"abcd", 2, "bf"},
        {"mxz", 3, "i"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = StringHash(input, k);
        Assert.Equal(expected, actual);
    }
}
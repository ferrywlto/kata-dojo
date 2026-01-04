public class Q3794_ReverseStringPrefix
{
    public string ReversePrefix(string s, int k)
    {
        return string.Empty;
    }
    public static TheoryData<string, int, string> TestData => new()
    {
        {"abcd", 2, "bacd"},
        {"xyz", 3, "zyx"},
        {"hey", 1, "hey"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = ReversePrefix(input, k);
        Assert.Equal(expected, actual);
    }

}

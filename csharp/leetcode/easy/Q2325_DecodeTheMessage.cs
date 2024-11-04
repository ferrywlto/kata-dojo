public class Q2325_DecodeTheMessage
{
    public string DecodeMessage(string key, string message)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        ["the quick brown fox jumps over the lazy dog", "vkbs bs t suepuv", "this is a secret"],
        ["eljuxhpwnyrdgtqkviszcfmabo", "zwx hnfx lqantp mnoeius ycgk vcnjrdb", "the five boxing wizards jump quickly"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string message, string expected)
    {
        var actual = DecodeMessage(input, message);
        Assert.Equal(expected, actual);
    }
}
public class Q2451_OddStringDifference
{
    public string OddString(string[] words)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"adc","wzy","abc"}, "abc"],
        [new string[] {"aaa","bob","ccc","ddd"}, "bob"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string expected)
    {
        var actual = OddString(input);
        Assert.Equal(expected, actual);
    }
}
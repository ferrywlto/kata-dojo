public class Q3798_LargestEvenNumber
{
    public string LargestEven(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"1112", "1112"},
        {"221", "22"},
        {"1", ""},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = LargestEven(input);
        Assert.Equal(expected, actual);
    }
}

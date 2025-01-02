public class Q2788_SplitStringsBySeparator
{
    public IList<string> SplitWordsBySeparator(IList<string> words, char separator)
    {
        return [];
    }

    public static TheoryData<string[], char, List<string>> TestData => new()
    {
        {["one.two.three","four.five","six"], '.', ["one","two","three","four","five","six"]},
        {["$easy$","$problem$"], '$', ["easy","problem"]},
        {["|||"], '|', []},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, char c, List<string> expected)
    {
        var actual = SplitWordsBySeparator(input, c);
        Assert.Equal(expected, actual);
    }
}
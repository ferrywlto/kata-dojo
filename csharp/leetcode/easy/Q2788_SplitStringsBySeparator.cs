public class Q2788_SplitStringsBySeparator
{
    // TC: O(n), n scale with length of words
    // SC: O(m), m scale with number of words split from input 
    public IList<string> SplitWordsBySeparator(IList<string> words, char separator)
    {
        var result = new List<string>();
        foreach (var w in words)
        {
            var temp = w.Split(separator);
            foreach (var token in temp)
            {
                if (!string.IsNullOrEmpty(token))
                {
                    result.Add(token);
                }
            }
        }
        return result;
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

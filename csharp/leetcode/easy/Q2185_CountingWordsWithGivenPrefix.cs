public class Q2185_CountingWordsWithGivenPrefix
{
    public int PrefixCount(string[] words, string pref) 
    {
        return 0;    
    }
    public static List<object[]> TestData =>
    [
        [new string[] { "pay", "attention", "practice", "attend" }, "at", 2],
        [new string[] { "leetcode","win","loops","success" }, "code", 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string prefix, int expected)
    {
        var actual = PrefixCount(input, prefix);
        Assert.Equal(expected, actual);
    }
}
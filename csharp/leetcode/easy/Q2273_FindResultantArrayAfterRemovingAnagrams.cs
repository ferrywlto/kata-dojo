public class Q2273_FindResultantArrayAfterRemovingAnagrams
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new string [] {"abba","baba","bbaa","cd","cd"}, new string[] {"abba","cd"}],
        [new string [] {"a","b","c","d","e"}, new string[] {"a","b","c","d","e"}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string[] expected)
    {
        var actual = RemoveAnagrams(input);
        Assert.Equal(expected, actual);
    }
}
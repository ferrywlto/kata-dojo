public class Q1967_NumStringsAppearSubstringsInWords
{
    public int NumOfStrings(string[] patterns, string word) 
    {
        return 0;    
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"a","abc","bc","d"}, "abc", 3],
        [new string[] {"a", "b", "c"}, "aaaaabbbbb", 2],
        [new string[] {"a","a","a"}, "ab", 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string word, int expected)
    {
        var actual = NumOfStrings(input, word);
        Assert.Equal(expected, actual);
    }
}
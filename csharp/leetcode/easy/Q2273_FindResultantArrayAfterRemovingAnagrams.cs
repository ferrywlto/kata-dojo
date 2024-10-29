public class Q2273_FindResultantArrayAfterRemovingAnagrams//(ITestOutputHelper output)
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        if (words.Length <= 1) return words;

        var list = new List<string>();
        var last = string.Empty;
        for (var i = 0; i < words.Length; i++)
        {
            var str = Encode(words[i]);
            if (str != last) list.Add(words[i]);
            last = str;
        }
        return list;
    }
    public string Encode(string input)
    {
        var x = input
            .GroupBy(c => c)
            .OrderBy(g => g.Key)
            .Select(g => $"{g.Key}{g.Count()}");
        return string.Join(',', x);
    }


    public static List<object[]> TestData =>
    [
        [new string [] {"abba","baba","bbaa","cd","cd"}, new List<string> {"abba","cd"}],
        [new string [] {"a","b","c","d","e"}, new List<string> {"a","b","c","d","e"}],
        [new string [] {"a","b","a"}, new List<string> {"a","b","a"}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, List<string> expected)
    {
        var actual = RemoveAnagrams(input);
        Assert.Equal(expected, actual);
    }
}
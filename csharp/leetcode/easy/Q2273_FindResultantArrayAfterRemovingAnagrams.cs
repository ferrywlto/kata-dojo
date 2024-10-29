public class Q2273_FindResultantArrayAfterRemovingAnagrams//(ITestOutputHelper output)
{
    // TC: O(n * m), n scale with length of words times m unique characters in each word
    // SC: O(k + m), k scale with number of anagram in words plus m unique characters in each word 
    public IList<string> RemoveAnagrams(string[] words)
    {
        if (words.Length <= 1) return words;

        var list = new List<string>();
        var last = new Dictionary<char, int>();
        for (var i = 0; i < words.Length; i++)
        {
            var str = Encode(words[i]);
            foreach (var k in str.Keys)
            {
                if (str.Count != last.Count
                || !last.TryGetValue(k, out var value)
                || value != str[k])
                {
                    list.Add(words[i]);
                    break;
                }
            }
            last = str;
        }
        return list;
    }
    public Dictionary<char, int> Encode(string input)
    {
        return input
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    public static List<object[]> TestData =>
    [
        [new string [] {"nelduncd","dcnndeul","uendlcnd","nluncedd","fozlsvr","osfvrlz","vozsrfl","dm","md","md","dm","md","dm","md","md","dm","dm","dm","dm","md","eatzkewuyx","a","wulzacir"}, new List<string> {"nelduncd","fozlsvr","dm","eatzkewuyx","a","wulzacir"}],
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
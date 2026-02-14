public class Q2942_FindWordsContainingCharacter
{
    // TC: O(n), n scale with length of words, it iterates total characters of times in all words
    // SC: O(m), m scale with number of words containing x to hold the result
    public IList<int> FindWordsContaining(string[] words, char x)
    {
        var result = new List<int>();
        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            if (word.Contains(x)) result.Add(i);
        }
        return result;
    }
    public static TheoryData<string[], char, int[]> TestData => new()
    {
        {["leet","code"], 'e', [0,1]},
        {["abc","bcd","aaaa","cbc"], 'a', [0,2]},
        {["abc","bcd","aaaa","cbc"], 'z', []},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, char c, int[] expected)
    {
        var actual = FindWordsContaining(input, c);
        Assert.Equal(expected, actual);
    }
}

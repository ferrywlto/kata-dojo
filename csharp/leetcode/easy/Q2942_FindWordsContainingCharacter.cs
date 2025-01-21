public class Q2942_FindWordsContainingCharacter
{
    public IList<int> FindWordsContaining(string[] words, char x)
    {
        return [];
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
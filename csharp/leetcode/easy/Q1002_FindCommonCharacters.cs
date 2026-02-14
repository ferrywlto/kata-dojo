class Q1002_FindCommonCharacters
{
    // TC: O(n*m^2), where n is the number of words and m is the average length of the words. 
    // This is because for each word, it checks each character against the common list (O(m)), and the FindIndex and Remove methods have a time complexity of O(m). The space complexity is O(m) for the lists.
    // SC: O(n+m), n is characters of first word, m is max length of other words
    public IList<string> CommonChars(string[] words)
    {
        if (words.Length == 1) return words[0].ToCharArray().Select(c => c.ToString()).ToList();

        // the common chars must be subset of any 1 word, thus we pick the first 1
        // as size of common will keep trimming and converge to end result
        var common = words[0].ToCharArray().ToList();
        for (var i = 1; i < words.Length; i++)
        {
            var charArray = words[i].ToCharArray().ToList();
            var keysToRemove = new List<char>();
            for (var j = 0; j < common.Count; j++)
            {
                if (charArray.FindIndex(c => c == common[j]) == -1)
                {
                    keysToRemove.Add(common[j]);
                }
                else
                {
                    charArray.Remove(common[j]);
                }
            }
            for (var k = 0; k < keysToRemove.Count; k++)
            {
                common.Remove(keysToRemove[k]);
            }
        }
        return common.Select(c => c.ToString()).ToList();
    }
}

class Q1002_FindCommonCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"bella","label","roller"}, new string[] {"e","l","l"}],
        [new string[] {"cool","lock","cook"}, new string[] {"c","o"}],
    ];
}

public class Q1002_FindCommonCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1002_FindCommonCharactersTestData))]
    public void OfficialTestCases(string[] input, string[] expected)
    {
        var sut = new Q1002_FindCommonCharacters();
        var actual = sut.CommonChars(input);
        Assert.Equal(expected, actual);
    }
}

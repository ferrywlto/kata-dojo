class Q1160_FindWordsThatCanBeFormedByCharacters
{
    // TC: O(n), n = total chars in words + length in chars
    // SC: O(n), n = lenth in chars + max length in words
    public int CountCharacters(string[] words, string chars)
    {
        var charsMap = chars.GroupBy(g => g).ToDictionary(grp => grp.Key, grp => grp.Count());
        var hashset = new HashSet<string>();

        var result = 0;
        for (var i = 0; i < words.Length; i++)
        {
            if (hashset.Contains(words[i]))
            {
                result += words[i].Length;
                continue;
            }
            var wordMap = new Dictionary<char, int>();
            for (var j = 0; j < words[i].Length; j++)
            {
                var charFromWord = words[i][j];
                if (!charsMap.TryGetValue(charFromWord, out var countFromChars))
                {
                    wordMap.Clear();
                    break;
                }

                if (!wordMap.TryGetValue(charFromWord, out var countFromWord))
                    wordMap.Add(charFromWord, 1);
                else
                    wordMap[charFromWord] = ++countFromWord;

                if (countFromWord > countFromChars)
                {
                    wordMap.Clear();
                    break;
                }
            }
            if (wordMap.Count > 0)
            {
                hashset.Add(words[i]);
                result += words[i].Length;
            }
        }
        return result;
    }
}
class Q1160_FindWordsThatCanBeFormedByCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"cat","bt","hat","tree"}, "atach", 6],
        [new string[] {"hello","world","leetcode"}, "welldonehoneyr", 10],
    ];
}
public class Q1160_FindWordsThatCanBeFormedByCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1160_FindWordsThatCanBeFormedByCharactersTestData))]
    public void OfficialTestCases(string[] input, string chars, int expected)
    {
        var sut = new Q1160_FindWordsThatCanBeFormedByCharacters();
        var actual = sut.CountCharacters(input, chars);
        Assert.Equal(expected, actual);
    }
}

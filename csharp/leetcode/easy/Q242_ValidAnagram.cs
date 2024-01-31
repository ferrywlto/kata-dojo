
namespace dojo.leetcode;

public class Q242_ValidAnagram
{
    public bool IsAnagram(string s, string t) 
    {
        if (s.Length != t.Length) return false;

        var dict_s = CharacterAnalysis(s);
        var dict_t = CharacterAnalysis(t);

        foreach(var pair in dict_t)
        {
            if (!dict_s.TryGetValue(pair.Key, out int value)) return false;

            if (!(value == pair.Value)) return false;
        }
        return true;
    }

    private Dictionary<string, int> CharacterAnalysis(string input)
    {
        var dict = new Dictionary<string, int>();

        foreach(var c in input)
        {
            var str = c.ToString();
            if(dict.TryGetValue(str, out var value)) 
            {
                dict[str]++;
            }
            else 
            {
                dict.Add(str, 1);
            }
        }
        return dict;
    }
}

public class Q242_ValidAnagramTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["anagram", "nagaram", true],
        ["anagram😀", "😀nagaram", true],
        ["rat", "car", false],
        ["ab", "a", false],
    ];
}

public class Q242_ValidAnagramTests
{
    [Theory]
    [ClassData(typeof(Q242_ValidAnagramTestData))]
    public void OfficialTestCases(string input1, string input2, bool expected)
    {
        var sut = new Q242_ValidAnagram();
        var actual = sut.IsAnagram(input1, input2);
        Assert.Equal(expected, actual);
    }
}
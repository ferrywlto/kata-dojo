using System.Text;

class Q1370_IncreasingDecreasingString
{
    // TC: O(n), n equals to the length of input s, plus the O(m log m) by sorting the keys in dict, since it is nearly constant to 26 max, it is negligible.
    // SC: O(n+m+p), n size of string builder equal to length of s + m unique characters in s, maximum 26, p = keys from dict (max 26)
    public string SortString(string s)
    {
        var dict = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if (dict.TryGetValue(c, out int value)) dict[c] = ++value;
            else dict.Add(c, 1);
        }

        var keys = dict.Keys.OrderBy(c => c).ToArray();
        var sb = new StringBuilder();
        while (sb.Length < s.Length)
        {
            for (var i = 0; i < keys.Length; i++)
            {
                if (dict[keys[i]] > 0)
                {
                    sb.Append(keys[i]);
                    dict[keys[i]]--;
                }
            }
            for (var j = keys.Length - 1; j >= 0; j--)
            {
                if (dict[keys[j]] > 0)
                {
                    sb.Append(keys[j]);
                    dict[keys[j]]--;
                }
            }
        }
        return sb.ToString();
    }
}
class Q1370_IncreasingDecreasingStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["aaaabbbbcccc", "abccbaabccba"],
        ["rat", "art"],
    ];
}
public class Q1370_IncreasingDecreasingStringTests
{
    [Theory]
    [ClassData(typeof(Q1370_IncreasingDecreasingStringTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1370_IncreasingDecreasingString();
        var actual = sut.SortString(input);
        Assert.Equal(expected, actual);
    }
}
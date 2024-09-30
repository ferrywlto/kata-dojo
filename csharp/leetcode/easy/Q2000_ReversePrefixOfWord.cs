using System.Text;

public class Q2000_PreversePrefixOfWord
{
    // TC: O(n), where n sacle with length of word.
    // SC: O(n), where n scale with length of word for StringBuilder to hold the result.
    public string ReversePrefix(string word, char ch)
    {
        for (var i = 0; i < word.Length; i++)
        {
            if (word[i] == ch)
            {
                var sb = new StringBuilder(word.Length);
                for (var j = i; j >= 0; j--)
                {
                    sb.Append(word[j]);
                }
                for (var k = i + 1; k < word.Length; k++)
                {
                    sb.Append(word[k]);
                }
                return sb.ToString();
            }
        }
        return word;
    }
    public static List<object[]> TestData =>
    [
        ["abcdefd", 'd', "dcbaefd"],
        ["xyxzxe", 'z', "zxyxxe"],
        ["abcd", 'z', "abcd"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char target, string expected)
    {
        var actual = ReversePrefix(input, target);
        Assert.Equal(expected, actual);
    }
}
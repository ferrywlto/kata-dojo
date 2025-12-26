using System.Text;

// TC: O(n), n scale with length of s
// SC: O(n), space used to store the result
public class Q3775_ReverseWordsWithSameVowelCount
{
    public string ReverseWords(string s)
    {
        var words = s.Split(' ');
        var firstWord = words[0];
        var vowelCount = CountVowels(firstWord);

        var sb = new StringBuilder(firstWord);
        for (var i = 1; i < words.Length; i++)
        {
            sb.Append(' ');
            var vc = CountVowels(words[i]);
            if (vc == vowelCount)
            {
                for (var j = words[i].Length - 1; j >= 0; j--)
                {
                    sb.Append(words[i][j]);
                }
            }
            else
            {
                sb.Append(words[i]);
            }
        }
        return sb.ToString();
    }

    private int CountVowels(string input)
    {
        var vowelCount = 0;
        foreach (var c in input)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                vowelCount++;
            }
        }
        return vowelCount;
    }

    public static TheoryData<string, string> TestData => new()
    {
        {"cat and mice", "cat dna mice"},
        {"book is nice", "book is ecin"},
        {"banana healthy", "banana healthy"},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = ReverseWords(input);
        Assert.Equal(expected, actual);
    }
}

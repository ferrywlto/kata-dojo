using System.Text;

public class Q3856_TrimTrailingVowels
{
    // TC: O(n), n scale with length of s
    // SC: O(n), for storing result, worst case no vowel found.
    public string TrimTrailingVowels(string s)
    {
        var sb = new StringBuilder(s);
        while (sb.Length > 0 && IsVowel(sb[^1]))
        {
            sb.Remove(sb.Length - 1, 1);
        }
        return sb.ToString();
    }
    private bool IsVowel(char input)
    {
        return input == 'a' || input == 'e' || input == 'i' || input == 'o' || input == 'u';
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"idea", "id"},
        {"day", "day"},
        {"aeiou", ""},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = TrimTrailingVowels(input);
        Assert.Equal(expected, actual);
    }
}

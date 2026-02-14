public class Q2309_GreatestEnglishLetterInUpperAndLowerCase
{
    // TC: O(n), n scale with length of s
    // SC: O(n+m), n scale with unique uppercase characters in s and m scale with unique lowercase characters in s, in worst case it cannot exceed 52
    public string GreatestLetter(string s)
    {
        var upperSet = new HashSet<char>();
        var lowerSet = new HashSet<char>();
        var maxChar = '/';
        foreach (var c in s)
        {
            if (char.IsUpper(c))
            {
                upperSet.Add(c);
                if (lowerSet.Contains(char.ToLower(c)))
                    if (c > maxChar)
                        maxChar = c;
            }
            else if (char.IsLower(c))
            {
                lowerSet.Add(c);
                var upperChar = char.ToUpper(c);
                if (upperSet.Contains(upperChar))
                    if (upperChar > maxChar)
                        maxChar = upperChar;
            }
        }

        return maxChar == '/' ? string.Empty : maxChar.ToString();
    }
    public static List<object[]> TestData =>
    [
        ["lEeTcOdE", "E"],
        ["arRAzFif", "R"],
        ["AbCdEfGhIjK", ""],
        ["AAAAA", ""],
        ["aaaaa", ""],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = GreatestLetter(input);
        Assert.Equal(expected, actual);
    }
}

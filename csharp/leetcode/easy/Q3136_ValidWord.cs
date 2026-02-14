public class Q3136_ValidWord
{
    // TC: O(n), n scale with length of word
    // SC: O(1), space used does not scale with input
    public bool IsValid(string word)
    {
        var vowelCount = 0;
        var nonVowelCount = 0;
        if (word.Length < 3) return false;
        foreach (var c in word)
        {
            if (!char.IsAsciiLetterOrDigit(c)) return false;
            else if (!char.IsAsciiDigit(c))
            {
                var lower = char.ToLower(c);
                if (
                    lower == 'a' ||
                    lower == 'e' ||
                    lower == 'i' ||
                    lower == 'o' ||
                    lower == 'u'
                ) vowelCount++;
                else nonVowelCount++;
            }
        }

        return vowelCount > 0 && nonVowelCount > 0;
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"234Adas", true},
        {"b3", false},
        {"a3$e", false},
        {"AhI", true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsValid(input);
        Assert.Equal(expected, actual);
    }
}

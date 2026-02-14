public class Q1763_LongestNiceSubstring
{
    public string LongestNiceSubstring(string s)
    {
        for (var i = s.Length; i > 0; i--)
        {
            for (var j = 0; j < s.Length - i; j++)
            {
                var temp = s[j..(j + i + 1)];
                if (IsNice(temp)) return temp;
            }
        }
        return string.Empty;
    }
    public bool IsNice(string input)
    {
        var set = new HashSet<char>(input);

        foreach (var c in set)
        {
            if (!set.Contains(char.ToLower(c)) ||
                !set.Contains(char.ToUpper(c))) return false;
        }
        return true;
    }

    public static List<object[]> TestData =>
    [
        ["YazaAay", "aAa"],
        ["Bb", "Bb"],
        ["c", ""],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = LongestNiceSubstring(input);
        Assert.Equal(expected, actual);
    }
}

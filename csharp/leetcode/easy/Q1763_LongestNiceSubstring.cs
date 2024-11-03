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
        var lower = new HashSet<char>();
        var upper = new HashSet<char>();
        foreach (var c in input)
        {
            if (char.IsLower(c)) lower.Add(char.ToUpper(c));
            else if (char.IsUpper(c)) upper.Add(c);
        }
        if (lower.Count != upper.Count) return false;

        foreach (var l in lower)
        {
            if (!upper.Remove(l)) return false;
        }
        return upper.Count == 0;
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
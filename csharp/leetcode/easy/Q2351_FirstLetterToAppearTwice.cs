public class Q2351_FirstLetterToAppearTwice
{
    // TC: O(n), n scale with length of s
    // SC: O(1), as input contains only lowercase characters
    public char RepeatedCharacter(string s)
    {
        var chars = new int[26];
        foreach (var c in s)
        {
            var idx = c - 'a';
            if (chars[idx] == 1) return c;
            chars[idx]++;
        }
        return ' ';
    }
    public static List<object[]> TestData =>
    [
        ["abccbaacz", 'c'],
        ["abcdd", 'd'],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char expected)
    {
        var actual = RepeatedCharacter(input);
        Assert.Equal(expected, actual);
    }
}

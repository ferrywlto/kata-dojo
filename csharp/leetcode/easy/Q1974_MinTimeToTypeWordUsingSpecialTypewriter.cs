public class Q1974_MinTimeToTypeWordUsingSpecialTypewriter
{
    // TC: O(n), n scale with length of word
    // SC: O(1), space used does not sacle with input
    public int MinTimeToType(string word)
    {
        var current = 'a';
        var result = 0;
        foreach (var c in word)
        {
            var temp = Math.Abs(c - current);
            if (temp > 13) temp = 26 - temp;
            result += temp + 1;
            current = c;
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        ["a", 1],
        ["z", 2],
        ["b", 2],
        ["o", 13],
        ["oc", 26],
        ["abc", 5],
        ["bza", 7],
        ["zjpc", 34],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinTimeToType(input);
        Assert.Equal(expected, actual);
    }
}
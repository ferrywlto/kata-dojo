public class Q2315_CountAsterisks
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int CountAsterisks(string s)
    {
        var result = 0;
        var barCount = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '|') barCount++;
            else if (s[i] == '*' && barCount % 2 == 0) result++;
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        ["l|*e*et|c**o|*de|", 2],
        ["iamprogrammer", 0],
        ["yo|uar|e**|b|e***au|tifu|l", 5],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountAsterisks(input);
        Assert.Equal(expected, actual);
    }
}
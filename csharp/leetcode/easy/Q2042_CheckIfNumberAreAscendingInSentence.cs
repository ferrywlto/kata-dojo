public class Q2042_CheckIfNumberAreAscendingInSentence
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public bool AreNumbersAscending(string s)
    {
        var currNum = -1;

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c >= '0' && c <= '9')
            {
                if (i < s.Length - 1 && s[i + 1] >= '0' && s[i + 1] <= '9')
                {
                    var num = (s[i] - '0') * 10 + (s[i + 1] - '0');
                    i++;
                    if (num > currNum) currNum = num;
                    else return false;
                }
                else
                {
                    var num = s[i] - '0';
                    if (num > currNum) currNum = num;
                    else return false;
                }
            }
        }
        if (currNum != -1) return true;
        return false;
    }
    public static List<object[]> TestData =>
    [
        ["1 box has 3 blue 4 red 6 green and 12 yellow marbles", true],
        ["hello world 5 x 5", false],
        ["sunset is at 7 51 pm overnight lows will be in the low 50 and 60 s", false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = AreNumbersAscending(input);
        Assert.Equal(expected, actual);
    }
}

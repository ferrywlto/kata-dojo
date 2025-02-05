using System.Text;

public class Q3114_LatestTimeYouCanObtainAfterReplacingCharacters
{
    // TC: O(1)
    // SC: same as time
    public string FindLatestTime(string s)
    {
        var sb = new StringBuilder(s);
        if (sb[0] == '?')
        {
            if (sb[1] == '?' || sb[1] < '2')
            {
                sb[0] = '1';
            }
            else
            {
                sb[0] = '0';
            }
        }
        if (sb[1] == '?')
        {
            if (sb[0] == '0')
            {
                sb[1] = '9';
            }
            else
            {
                sb[1] = '1';
            }
        }
        if (sb[3] == '?')
        {
            sb[3] = '5';
        }
        if (sb[4] == '?')
        {
            sb[4] = '9';
        }
        return sb.ToString();
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"1?:?4", "11:54"},
        {"0?:5?", "09:59"},
        {"?3:12", "03:12"},
        {"??:12", "11:12"},
        {"??:??", "11:59"},
        {"00:??", "00:59"},
        {"?2:2?", "02:29"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = FindLatestTime(input);
        Assert.Equal(expected, actual);
    }
}
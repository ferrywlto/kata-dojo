using System.Text;

class Q1736_LatestTimeByReplacingHiddenDigits
{
    // TC: O(1), as the input is always fixed in length
    // SC: O(1), the space used in string builder is always the same
    public string MaximumTime(string time)
    {
        const char hidden = '?';
        var sb = new StringBuilder(time);
        if (sb[0] == hidden && sb[1] == hidden)
        {
            sb[0] = '2'; sb[1] = '3';
        }
        if (sb[3] == hidden && sb[4] == hidden)
        {
            sb[3] = '5'; sb[4] = '9';
        }

        if (sb[0] == hidden)
        {
            if (sb[1] == '0' || sb[1] == '1' || sb[1] == '2' || sb[1] == '3') sb[0] = '2';
            else sb[0] = '1';
        }
        if (sb[1] == hidden)
        {
            if (sb[0] == '2') sb[1] = '3';
            else sb[1] = '9';
        }
        if (sb[3] == hidden) sb[3] = '5';
        if (sb[4] == hidden) sb[4] = '9';

        return sb.ToString();
    }
}
class Q1736_LatestTimeByReplacingHiddenDigitsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["2?:?0", "23:50"],
        ["0?:3?", "09:39"],
        ["1?:22", "19:22"],
        ["??:3?", "23:39"],
        ["?0:15", "20:15"],
        ["?4:03", "14:03"],
    ];
}
public class Q1736_LatestTimeByReplacingHiddenDigitsTests
{
    [Theory]
    [ClassData(typeof(Q1736_LatestTimeByReplacingHiddenDigitsTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1736_LatestTimeByReplacingHiddenDigits();
        var actual = sut.MaximumTime(input);
        Assert.Equal(expected, actual);
    }
}

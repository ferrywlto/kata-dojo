using System.Text;

public class Q3216_LexicographicallySmallestStringAfterSwap
{
    // TC: O(n), n sacle with length of s
    // SC: O(n), same as time as the StringBuilder need to hold the whole string to manipulate 
    public string GetSmallestString(string s)
    {
        var sb = new StringBuilder(s);
        for (var i = 0; i < sb.Length - 1; i++)
        {
            var valCurr = sb[i] - '0';
            var valNext = sb[i + 1] - '0';
            if (valCurr > valNext &&
            valCurr % 2 == valNext % 2)
            {
                (sb[i], sb[i + 1]) = (sb[i + 1], sb[i]);
                return sb.ToString();
            }
        }
        return s;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"45320", "43520"},
        {"001", "001"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = GetSmallestString(input);
        Assert.Equal(expected, actual);
    }
}

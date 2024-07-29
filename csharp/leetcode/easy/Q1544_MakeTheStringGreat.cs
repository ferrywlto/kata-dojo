using System.Text;

class Q1544_MakeTheStringGreat
{
    public string MakeGood(string s)
    {
        var sb = new StringBuilder(s);
        var matchFound = true;
        while(matchFound)
        {
            matchFound = false;
            for(var i=0; i<sb.Length-1; i++)
            {
                if(Math.Abs(sb[i]-sb[i+1]) == 32)
                {
                    var pattern1 = $"{sb[i]}{sb[i + 1]}";
                    var pattern2 = $"{sb[i + 1]}{sb[i]}";
                    sb.Replace(pattern1, string.Empty);
                    sb.Replace(pattern2, string.Empty);
                    matchFound = true;
                }
            }
        }
        return sb.ToString();
    }
}
class Q1544_MakeTheStringGreatTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["leEeetcode", "leetcode"],
        ["abBAcC", ""],
        ["s", "s"],
    ];
}
public class Q1544_MakeTheStringGreatTests
{
    [Theory]
    [ClassData(typeof(Q1544_MakeTheStringGreatTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1544_MakeTheStringGreat();
        var actual = sut.MakeGood(input);
        Assert.Equal(expected, actual);
    }
}
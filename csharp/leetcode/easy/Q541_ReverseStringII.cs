
using System.Text;

class Q541_ReverseStringII
{
    // TC: O(n)
    // SC: O(n)
    public string ReverseStr(string s, int k) 
    {
        if (s.Length == 1 || k == 1) return s;

        var sb = new StringBuilder(s);
        for (var i=0; i*k< s.Length; i++)
        {
            if(i%2 == 0) 
            {
                ReverseString(sb, k * i, Math.Min(k * (i + 1), s.Length) - 1);
            }
        }
        return sb.ToString();    
    }

    public void ReverseString(StringBuilder sb, int startIdx, int endIdx)
    {
        char temp = ' ';
        var times = (endIdx - startIdx) / 2;

        for (var i = 0; i <= times; i++)
        {
            if (startIdx + i == endIdx - i) break;

            temp = sb[i + startIdx];
            sb[i + startIdx] = sb[endIdx - i];
            sb[endIdx - i] = temp;
        }
    }
}

class Q541_ReverseStringIITestData: TestData
{
    protected override List<object[]> Data => 
    [
        // for k=2, 0,1 -> 4,5 -> 8,9
        // 0*2k = 0, (0*2k+(k-1)) = 1 ->  1*2k = 4, 1*2k+(k-1) = 5, 2*2k = 8, 2*2k+(k-1) = 9
        // for k=3, 0,2 -> 6,8 -> 12,14
        // 0, 2, -> 6, 8 -> 12, 14 
        ["abcdefg", 2, "bacdfeg"],
        ["abcd", 2, "bacd"],
        ["abcdefgh", 3, "cbadefhg"],
    ];
}

public class Q541_ReverseStringIITests
{
    [Theory]
    [ClassData(typeof(Q541_ReverseStringIITestData))]
    public void OfficialTestCases(string input, int k, string expected)
    {
        var sut = new Q541_ReverseStringII();
        var actual = sut.ReverseStr(input, k);
        Assert.Equal(expected, actual);
    }
}
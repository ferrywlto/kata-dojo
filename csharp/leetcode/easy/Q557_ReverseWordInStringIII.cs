using System.Text;

namespace dojo.leetcode;

public class Q557_ReverseWordInStringIII
{
    // TC: O(n^2)
    // SC: O(n)
    public string ReverseWords_Simple(string s)
    {
        var newStr = string.Join(" ", s.Split(" ").Select(s => string.Join(string.Empty, s.Reverse().ToArray())));

        return newStr;
    }

    // this is slightly faster and use fewer memory caused by addition array creation
    // TC: O(n)
    // SC: O(n)
    public string ReverseWords_Efficient(string s)
    {
        var helper = new Q541_ReverseStringII();
        // this use index approach
        var sb = new StringBuilder(s);

        var startIdx = 0;
        var endIdx = 0;
        for(var i=0; i<s.Length; i++)
        {
            if(s[i] == ' ')
            {
                endIdx = i - 1;
                ReverseStringByIndex(sb, startIdx, endIdx);
                startIdx = ++i;
            }
            else if(i == s.Length-1)
            {
                ReverseStringByIndex(sb, startIdx, s.Length-1);
            }
        }
        return sb.ToString();
    }

    public void ReverseStringByIndex(StringBuilder sb, int startIdx, int endIdx)
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

public class Q557_ReverseWordInStringIIITestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc"],
        ["God Ding", "doG gniD"],
    ];
}

public class Q557_ReverseWordInStringIIITests
{
    [Theory]
    [ClassData(typeof(Q557_ReverseWordInStringIIITestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q557_ReverseWordInStringIII();
        var actual = sut.ReverseWords_Efficient(input);
        Assert.Equal(expected, actual);
    }
}
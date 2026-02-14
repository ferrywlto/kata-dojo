using System.Text;

class Q844_BackspaceStringCompare
{
    // TC: O(n), n is length of s + length of t
    // SC: O(n) is not count the string builder
    public bool BackspaceCompare(string s, string t)
    {
        return Print(s).Trim() == Print(t).Trim();
    }

    private string Print(string input)
    {
        var idx1 = 0;
        var sb = new StringBuilder(input);
        for (var i = 0; i < input.Length; i++)
        {
            if (sb[i] == '#')
            {
                idx1--;
                if (idx1 < 0) idx1 = 0;
                sb[i] = ' ';
                sb[idx1] = ' ';
            }
            else if (idx1 != i)
            {
                sb[idx1] = sb[i];
                sb[i] = ' ';
                idx1++;
            }
            else idx1++;
        }
        var result = sb.ToString();
        return result;
    }

    public bool BackspaceCompare_O1Space(string S, string T)
    {
        int i = S.Length - 1, j = T.Length - 1;
        int skipS = 0, skipT = 0;

        while (i >= 0 || j >= 0)
        { // While there are characters to compare
            while (i >= 0)
            { // Find position of next possible char in build(S)
                if (S[i] == '#') { skipS++; i--; }
                else if (skipS > 0) { skipS--; i--; }
                else break;
            }
            while (j >= 0)
            { // Find position of next possible char in build(T)
                if (T[j] == '#') { skipT++; j--; }
                else if (skipT > 0) { skipT--; j--; }
                else break;
            }
            // If two actual characters are different
            if (i >= 0 && j >= 0 && S[i] != T[j])
                return false;
            // If expecting to compare char vs nothing
            if ((i >= 0) != (j >= 0))
                return false;
            i--; j--;
        }
        return true;
    }
}



class Q844_BackspaceStringCompareTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["xywrrmp", "xywrrmu#p", true],
        ["a##c", "#a#c", true],
        ["ab#c", "ad#c", true],
        ["ab##", "c#d#", true],
        ["a#c", "b", false],
    ];
}

public class Q844_BackspaceStringCompareTests
{
    [Theory]
    [ClassData(typeof(Q844_BackspaceStringCompareTestData))]
    public void OfficialTestCase(string input1, string input2, bool expected)
    {
        var sut = new Q844_BackspaceStringCompare();
        var actual = sut.BackspaceCompare_O1Space(input1, input2);
        Assert.Equal(expected, actual);
    }
}

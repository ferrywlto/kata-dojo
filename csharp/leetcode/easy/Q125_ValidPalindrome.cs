using System.Collections.Generic;
using System.Text;

class Q125_ValidPalindromeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [true, "A man, a plan, a canal: Panama"],
        [false, "race a car"],
        [true, " "],
        [true, ".,"],
        [true, "......a....."],
        [true, "0z;z   ; 0"],
    ];
}

public class Q125_ValidPalindromeTests
{
    [Theory]
    [ClassData(typeof(Q125_ValidPalindromeTestData))]
    public void OfficialTestCases(bool expected, string input)
    {
        var sut = new Q125_ValidPalindrome();
        var actual = sut.IsPalindrome_2Pointers(input);
        Assert.Equal(expected, actual);
    }
}

/*
Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.
*/

/* ASCII
0-9: 48-57
A-Z: 65-90
a-z: 97-122
*/
class Q125_ValidPalindrome
{
    // TC: O(n), SC: O(n)
    public bool IsPalindrome(string s)
    {
        if (s.Length is 0 or 1) return true;

        // cleanse
        var builder = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (c >= 48 && c <= 57)
            {
                builder.Append(c);
            }
            else if (c >= 65 && c <= 90)
            {
                builder.Append((char)(c + 32));
            }
            else if (c >= 97 && c <= 122)
            {
                builder.Append(c);
            }
        }
        if (builder.Length is 0 or 1) return true;

        // Only have to compare n/2 times
        var times = builder.Length % 2 == 0
            ? builder.Length
            : builder.Length - 1;
        times /= 2;

        for (var i = 0; i < times; i++)
        {
            if (builder[i] != builder[^(i + 1)]) return false;
        }

        return true;
    }

    // TC: O(n), SC: O(1), more efficient solution from Copilot
    public bool IsPalindrome_2Pointers(string s)
    {
        int i = 0, j = s.Length - 1;

        // The idea is to move the pointers to next letter or digit from both direction before compare, skipping all non-alphanumeric characters
        // This works because after trimming they should be located at the same mirrored position 
        while (i < j)
        {
            if (!Char.IsLetterOrDigit(s[i])) i++;

            else if (!Char.IsLetterOrDigit(s[j])) j--;

            else
            {
                if (Char.ToLower(s[i]) != Char.ToLower(s[j])) return false;
                i++;
                j--;
            }
        }
        return true;
    }
}

using System.Text;

public class Q125_ValidPalindromeTestData {}
public class Q125_ValidPalindromeTests {
    [Theory]
    [InlineData(true, "A man, a plan, a canal: Panama")]
    [InlineData(false, "race a car")]
    [InlineData(true, " ")]
    [InlineData(true, ".,")]
    [InlineData(true, "......a.....")]
    [InlineData(true, "0z;z   ; 0")]
    public void OfficialTestCases(bool expected, string input) {
        var sut = new Q125_ValidPalindrome();
        var actual = sut.IsPalindrome(input);
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
public class Q125_ValidPalindrome {
    
    public bool IsPalindrome(string s) {
        if (s.Length is 0 or 1) return true;

        // cleanse
        var builder = new StringBuilder();
        for(var i=0; i<s.Length; i++) {
            char c = s[i];

            if (c >= 48 && c <= 57)
            {
                builder.Append(c);
            }
            else if (c >= 65 && c <= 90) 
            {
                builder.Append((char)(c+32));
            } 
            else if (c >= 97 && c <= 122) 
            {
                builder.Append(c);
            }
        }
        // Console.WriteLine($"after cleansed: {builder.ToString()}");

        if(builder.Length is 0 or 1) return true;

        // Only have to compare n/2 times
        var times = builder.Length % 2 == 0 
            ? builder.Length 
            : builder.Length - 1;
        times /= 2;

        for(var i=0; i<times; i++) 
        {
            if (builder[i] != builder[^(i + 1)]) return false;
        }

        return true;
    }
}
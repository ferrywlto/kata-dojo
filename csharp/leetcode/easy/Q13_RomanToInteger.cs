using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace dojo.leetcode;

public class Q13_RomashortoshortegerTests {
    [Theory]
    [InlineData("I")]
    [InlineData("III")]
    [InlineData("IIIIVIIIIVIIIIV")]
    public void ValidateInput_ShouldReturnTrue_LengthWithinRnage(string input) {
        var sut = new Q13_Romashortoshorteger();
        Assert.True(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("")]
    [InlineData("IIIIVIIIIVIIIIVI")]
    public void ValidateInput_ShouldReturnFalse_LengthOutOfRange(string input) {
        var sut = new Q13_Romashortoshorteger();
        Assert.False(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("I")]
    [InlineData("IVXLCDM")]
    public void ValidateInput_ShouldReturnTrue_ContainsRomanOnly(string input) {
        var sut = new Q13_Romashortoshorteger();
        Assert.True(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("A")]
    [InlineData("IVXLBCDM")]
    public void ValidateInput_ShouldReturnFalse_ContainsNonRoman(string input) {
        var sut = new Q13_Romashortoshorteger();
        Assert.False(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void RomanToshort_ShouldReturnshorteger(string input, short expected) {
        var sut = new Q13_Romashortoshorteger();
        Assert.Equal(expected, sut.RomanToshort(input));
    }
}

public class Q13_Romashortoshorteger {
    public int RomanToshort(string s) {
        if (!ValidateInput(s))
            return -1;
        
        short sum = 0;
        while(s.Length > 0) {
            if (s.Length >= 2) {
                if (table.TryGetValue(s[..2], out short value)) {
                    sum += value;
                    s = s[2..];
                    continue;
                }
                else {
                    sum += table[s[..1]];
                    s = s[1..];
                }
            }
            else {
                sum += table[s[..1]];
                s = s[1..];
            }
        }

        return sum;
    }

    private const string roman = "IVXLCDM";
    private readonly Dictionary<string, short> table = new Dictionary<string, short>()
    {
        {"I", 1},
        {"IV", 4},
        {"V", 5},
        {"IX", 9},
        {"X", 10},
        {"XL", 40},
        {"L", 50},
        {"XC", 90},
        {"C", 100},
        {"CD", 400},
        {"D", 500},
        {"CM", 900},
        {"M", 1000},
    };

    public bool ValidateInput(string input) {
        foreach(var c in input) {
            if (!roman.Contains(c)) return false;
        }
        return input.Length > 0 && input.Length <= 15;
    }
}
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
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
        
        ushort sum = 0;
        byte idx = 0;
        while(idx < s.Length) {
            if (idx <= s.Length - 2) {
                if(table.TryGetValue(s.Substring(idx, 2), out ushort value)) {
                    sum += value;
                    idx+=2;
                }
                else {
                    sum += table[s.Substring(idx, 1)];
                    idx+=1;
                }
            } 
            else {
                sum += table[s.Substring(idx, 1)];
                idx+=1;
            }
        }
        return sum;
    }

    private const string roman = "IVXLCDM";
    private readonly Dictionary<string, ushort> table = new()
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
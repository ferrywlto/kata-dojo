using System.Collections.Immutable;

namespace dojo.leetcode;

public class Q13_RomainToIntegerTests {
    [Theory]
    [InlineData("I")]
    [InlineData("III")]
    [InlineData("IIIIVIIIIVIIIIV")]
    public void ValidateInput_ShouldReturnTrue_LengthWithinRnage(string input) {
        var sut = new Q13_RomainToInteger();
        Assert.True(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("")]
    [InlineData("IIIIVIIIIVIIIIVI")]
    public void ValidateInput_ShouldReturnFalse_LengthOutOfRange(string input) {
        var sut = new Q13_RomainToInteger();
        Assert.False(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("I")]
    [InlineData("IVXLCDM")]
    public void ValidateInput_ShouldReturnTrue_ContainsRomanOnly(string input) {
        var sut = new Q13_RomainToInteger();
        Assert.True(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("A")]
    [InlineData("IVXLBCDM")]
    public void ValidateInput_ShouldReturnFalse_ContainsNonRoman(string input) {
        var sut = new Q13_RomainToInteger();
        Assert.False(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void RomanToInt_ShouldReturnInteger(string input, int expected) {
        var sut = new Q13_RomainToInteger();
        Assert.Equal(expected, sut.RomanToInt(input));
    }
}

public class Q13_RomainToInteger {
    public int RomanToInt(string s) {
        if (!ValidateInput(s))
            return -1;
        
        var sum = 0;
        while(s.Length > 0) {
            if (s.Length >= 2) {
                var key = s[..2];
                if (table.TryGetValue(key, out int value)) {
                    sum += value;
                    s = s[2..];
                    Console.WriteLine($"key:{key}, value:{value}, s:{s}, sum:{sum}");
                    continue;
                }
                else {
                    key = s[..1];
                    if (table.TryGetValue(key, out value)) {
                        sum += value;
                        s = s[1..];
                        Console.WriteLine($"key:{key}, value:{value}, s:{s}, sum:{sum}");
                        continue;
                    }
                }
            }
            else {
                var key = s[..1];
                if (table.TryGetValue(key, out int value)) {
                    sum += value;
                    s = s[1..];
                    Console.WriteLine($"key:{key}, value:{value}, s:{s}, sum:{sum}");
                    continue;
                }
            }
        }

        return sum;
    }

    private const string roman = "IVXLCDM";
    private readonly ImmutableDictionary<string, int> table = new Dictionary<string, int>()
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
    }.ToImmutableDictionary();

    public bool ValidateInput(string input) {
        foreach(var c in input) {
            if (!roman.Contains(c)) return false;
        }
        return input.Length > 0 && input.Length <= 15;
    }
}
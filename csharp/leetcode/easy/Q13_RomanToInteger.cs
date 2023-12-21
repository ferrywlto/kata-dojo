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
        

        return 0;
    }

    const string roman = "IVXLCDM";
    public bool ValidateInput(string input) {
        foreach(var c in input) {
            if (!roman.Contains(c)) return false;
        }
        return input.Length > 0 && input.Length <= 15;
    }
}
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
}

public class Q13_RomainToInteger {
    public int RomanToInt(string s) {
        return 0;
    }

    public bool ValidateInput(string input) {
        return input.Length > 0 && input.Length <= 15;
    }
}
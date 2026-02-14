public class Q13_RomashortoshortegerTests
{
    [Theory]
    [InlineData("I")]
    [InlineData("III")]
    [InlineData("IIIIVIIIIVIIIIV")]
    public void ValidateInput_ShouldReturnTrue_LengthWithinRnage(string input)
    {
        var sut = new Q13_Romashortoshorteger();
        Assert.True(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("")]
    [InlineData("IIIIVIIIIVIIIIVI")]
    public void ValidateInput_ShouldReturnFalse_LengthOutOfRange(string input)
    {
        var sut = new Q13_Romashortoshorteger();
        Assert.False(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("I")]
    [InlineData("IVXLCDM")]
    public void ValidateInput_ShouldReturnTrue_ContainsRomanOnly(string input)
    {
        var sut = new Q13_Romashortoshorteger();
        Assert.True(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("A")]
    [InlineData("IVXLBCDM")]
    public void ValidateInput_ShouldReturnFalse_ContainsNonRoman(string input)
    {
        var sut = new Q13_Romashortoshorteger();
        Assert.False(sut.ValidateInput(input));
    }
    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    [InlineData("IV", 4)]
    public void RomanToshort_ShouldReturnshorteger(string input, short expected)
    {
        var sut = new Q13_Romashortoshorteger();
        Assert.Equal(expected, sut.RomanToInt_CorrectImplementation(input));
    }
}

// Tried even enum approach, but it still use 1MB more memory and took 10ms more time than my Dictionary approach
// Inspired by other developers, modified the implemenation to:
// 1. use char array instaed of string
// 2. use switch instead of dictionary
// 3. consider the nature that if the smaller value followed by a larger value, it should be minus instead of addition.
// Speed: 46ms (99.75%), Memory: 47.29MB (73.03%)
class Q13_Romashortoshorteger
{
    public int RomanToInt_CorrectImplementation(string s)
    {
        if (!ValidateInput(s))
            return -1;

        short sum = 0;
        var chars = s.ToCharArray();
        for (var i = 0; i < chars.Length - 1; i++)
        {
            if (GetValue(chars[i + 1]) > GetValue(chars[i]))
                sum -= GetValue(chars[i]);
            else
                sum += GetValue(chars[i]);
        }
        return sum + GetValue(chars[^1]);
    }

    private static short GetValue(char c)
    {
        return c switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => 0,
        };
    }

    public int RomanToInt(string s)
    {
        if (!ValidateInput(s))
            return -1;

        ushort sum = 0;
        byte idx = 0;
        while (idx < s.Length)
        {
            if (idx <= s.Length - 2)
            {
                if (table.TryGetValue(s.Substring(idx, 2), out ushort value))
                {
                    sum += value;
                    idx += 2;
                }
                else
                {
                    sum += table[s.Substring(idx, 1)];
                    idx += 1;
                }
            }
            else
            {
                sum += table[s.Substring(idx, 1)];
                idx += 1;
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

    public bool ValidateInput(string input)
    {
        foreach (var c in input)
        {
            if (!roman.Contains(c)) return false;
        }
        return input.Length > 0 && input.Length <= 15;
    }
}

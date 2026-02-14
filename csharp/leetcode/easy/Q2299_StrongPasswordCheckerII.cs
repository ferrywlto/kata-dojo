public class Q2299_StrongPasswordCheckerII
{
    // TC: O(n), n scales with length of password
    // SC: O(1), space used does not scale with input
    public bool StrongPasswordCheckerII(string password)
    {
        if (password.Length < 8) return false;

        var uppercaseCount = 0;
        var lowercaseCount = 0;
        var digitCount = 0;
        var symbolCount = 0;
        var symbols = "!@#$%^&*()-+".ToHashSet();
        for (var i = 0; i < password.Length; i++)
        {
            if (i > 0 && password[i] == password[i - 1]) return false;
            else if (char.IsAsciiLetterUpper(password[i])) uppercaseCount++;
            else if (char.IsAsciiLetterLower(password[i])) lowercaseCount++;
            else if (char.IsAsciiDigit(password[i])) digitCount++;
            else if (symbols.Contains(password[i])) symbolCount++;
        }
        return uppercaseCount > 0
            && lowercaseCount > 0
            && digitCount > 0
            && symbolCount > 0;
    }
    public static List<object[]> TestData =>
    [
        ["IloveLe3tcode!", true],
        ["Me+You--IsMyDream", false],
        ["1aB!", false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = StrongPasswordCheckerII(input);
        Assert.Equal(expected, actual);
    }
}

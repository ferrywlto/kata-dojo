public class Q3941_PasswordStrength
{
    // TC: O(n), n scale with length of password
    // SC: O(1), space used does not scale with input
    public int PasswordStrength(string password)
    {
        // the last character 'z' is on ASCII table is 122
        Span<bool> seen = stackalloc bool[123];
        for (var i = 0; i < password.Length; i++)
        {
            seen[password[i]] = true;
        }

        var result = 0;
        for (var i = 33; i < seen.Length; i++)
        {
            if (seen[i])
            {

                result += i switch
                {
                    < 48 or 64 => 5, // !@#$
                    <= 57 => 3, // 0-9
                    <= 90 => 2, // A-Z
                    _ => 1 // a-z
                };
            }
        }
        return result;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "aA1!", 11 },
        { "bbB11#", 11 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = PasswordStrength(input);
        Assert.Equal(expected, actual);
    }
}

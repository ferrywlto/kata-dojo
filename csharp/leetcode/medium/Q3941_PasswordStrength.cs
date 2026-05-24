public class Q3941_PasswordStrength
{
    public int PasswordStrength(string password)
    {
        return 0;
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

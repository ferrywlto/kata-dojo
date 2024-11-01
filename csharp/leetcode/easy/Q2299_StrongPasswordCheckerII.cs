public class Q2299_StrongPasswordCheckerII
{
    public bool StrongPasswordCheckerII(string password)
    {
        return false;
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
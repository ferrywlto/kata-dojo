public class Q2351_FirstLetterToAppearTwice
{
    public char RepeatedCharacter(string s)
    {
        return ' ';
    }
    public static List<object[]> TestData =>
    [
        ["abccbaacz", 'c'],
        ["abcdd", 'd'],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char expected)
    {
        var actual = RepeatedCharacter(input);
        Assert.Equal(expected, actual);
    }
}
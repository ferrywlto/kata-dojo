public class Q2423_RemoveLetterToEqualizeFrequency
{
    public bool EqualFrequency(string word)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        ["abcc", true],
        ["aazz", false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = EqualFrequency(input);
        Assert.Equal(expected, actual);
    }
}
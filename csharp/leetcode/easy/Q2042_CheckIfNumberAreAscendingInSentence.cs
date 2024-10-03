public class Q2042_CheckIfNumberAreAscendingInSentence
{
    public bool AreNumbersAscending(string s) 
    {
        return false;    
    }
    public static List<object[]> TestData =>
    [
        ["1 box has 3 blue 4 red 6 green and 12 yellow marbles", true],
        ["hello world 5 x 5", false],
        ["sunset is at 7 51 pm overnight lows will be in the low 50 and 60 s", false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = AreNumbersAscending(input);
        Assert.Equal(expected, actual);
    }
}
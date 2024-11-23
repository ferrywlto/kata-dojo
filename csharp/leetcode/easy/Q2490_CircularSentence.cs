public class Q2490_CircularSentence
{
    public bool IsCircularSentence(string sentence) 
    {
        return false;   
    }
    public static List<object[]> TestData =>
    [
        ["leetcode exercises sound delightful", true],
        ["eetcode", true],
        ["Leetcode is cool", false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsCircularSentence(input);
        Assert.Equal(expected, actual);
    }
}
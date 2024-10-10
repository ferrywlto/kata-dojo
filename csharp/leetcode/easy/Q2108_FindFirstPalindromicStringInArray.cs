public class Q2108_FindFirstPalindromicStringInArray
{
    public string FirstPalindrome(string[] words)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"abc","car","ada","racecar","cool"}, "ada"],
        [new string[] {"notapalindrome","racecar"}, "racecar"],
        [new string[] {"def","ghi"}, string.Empty],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string expected)
    {
        var actual = FirstPalindrome(input);
        Assert.Equal(expected, actual);
    }
}
public class Q2108_FindFirstPalindromicStringInArray
{
    // TC: O(n), n scales with length of words
    // SC: O(1), space used does not scale with input
    public string FirstPalindrome(string[] words)
    {
        foreach (var w in words)
        {
            var isPalindromic = true;
            for (var i = 0; i < w.Length / 2; i++)
            {
                if (w[i] != w[^(i + 1)])
                {
                    isPalindromic = false;
                    break;
                }
            }
            if (isPalindromic) return w;
        }
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

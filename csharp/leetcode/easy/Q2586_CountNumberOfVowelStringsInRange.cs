public class Q2586_CountNumberOfVowelStringsInRange
{
    // TC: O(n), n scale with length of words.
    // SC: O(1), space used does not scale with input. 
    public int VowelStrings(string[] words, int left, int right)
    {
        var count = 0;
        for (var i = left; i <= right; i++)
        {
            if (IsStandAndEndWithVowel(words[i])) count++;
        }
        return count;
    }
    public bool IsStandAndEndWithVowel(string s) => IsVowel(s[0]) && IsVowel(s[^1]);
    public bool IsVowel(char c) =>
        c == 'a' ||
        c == 'e' ||
        c == 'i' ||
        c == 'o' ||
        c == 'u';
    public static List<object[]> TestData =>
    [
        [new string[] {"are","amy","u"}, 0, 2, 2],
        [new string[] {"hey","aeo","mu","ooo","artro"}, 1, 4, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int left, int right, int expected)
    {
        var actual = VowelStrings(input, left, right);
        Assert.Equal(expected, actual);
    }
}

using System.Text;

public class Q2062_CountVowelSubstringsOfString
{
    readonly HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];

    // TC: O(n), n scale with length of word
    // SC: O(1), space used are always capped at five entries for hashset
    public int CountVowelSubstrings(string word)
    {
        if (word.Length < 5) return 0;

        var result = 0;
        for (var i = 0; i < word.Length; i++)
        {
            if (!vowels.Contains(word[i])) continue;

            var hashSet = new HashSet<char>();
            for (var j = i; j < word.Length; j++)
            {
                if (!vowels.Contains(word[j])) break;
                hashSet.Add(word[j]);

                if (hashSet.Count == 5) result++;
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        ["aeiouu", 2],
        ["unicornarihan", 0],
        ["cuaieuouac", 7],
        ["cuaieuouacaeiou", 8],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountVowelSubstrings(input);
        Assert.Equal(expected, actual);
    }
}

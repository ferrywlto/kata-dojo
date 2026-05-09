using System.Text;

public class Q3913_SortVowelsByFrequency
{
    // TC: O(n), n scale with length of s
    // SC: O(n) if counting string builder to hold result, otherwise O(1)
    public string SortVowels(string s)
    {
        Span<int> freq = stackalloc int[26];
        Span<int> firstOccur = stackalloc int[26];
        Span<char> vowels = ['a', 'e', 'i', 'o', 'u'];
        Span<(char ch, int freq, int firstIdx)> toSort = stackalloc (char ch, int freq, int firstIdx)[5];

        for (var i = 0; i < firstOccur.Length; i++) firstOccur[i] = -1;
        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            var idx = c - 'a';
            freq[idx]++;

            if (firstOccur[idx] == -1)
                firstOccur[idx] = i;
        }

        for (var i = 0; i < vowels.Length; i++)
        {
            var c = vowels[i];
            var idx = c - 'a';
            toSort[i] = (c, freq[idx], firstOccur[idx]);
        }

        toSort.Sort((a, b) =>
        {
            if (a.freq > b.freq) return -1;
            if (a.freq < b.freq) return 1;
            return a.firstIdx > b.firstIdx ? 1 : -1;
        });

        var sb = new StringBuilder(s);
        var replaceItemIdx = 0;
        for (var i = 0; i < sb.Length; i++)
        {
            if (sb[i] == 'a' || sb[i] == 'e' || sb[i] == 'i' || sb[i] == 'o' || sb[i] == 'u')
            {
                sb[i] = toSort[replaceItemIdx].ch;
                toSort[replaceItemIdx].freq--;
                if (toSort[replaceItemIdx].freq == 0)
                    replaceItemIdx++;
            }
        }
        return sb.ToString();
    }

    public static TheoryData<string, string> TestData => new()
    {
        { "leetcode", "leetcedo" },
        { "aeiaaioooa", "aaaaoooiie" },
        { "baeiou", "baeiou" },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = SortVowels(input);
        Assert.Equal(expected, actual);
    }
}

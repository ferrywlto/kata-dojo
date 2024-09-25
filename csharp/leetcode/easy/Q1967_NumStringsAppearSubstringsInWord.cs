public class Q1967_NumStringsAppearSubstringsInWords
{
    // TC: O(n*m), n scales with total characters in patterns times total characters in word
    // SC: O(m), m scales with unique characters in word for early termination
    public int NumOfStrings(string[] patterns, string word)
    {
        var chars = word.ToHashSet();
        var result = 0;
        foreach (var s in patterns)
        {
            if (s.Length > word.Length) continue;
            foreach (var c in s)
            {
                if (!chars.Contains(c)) continue;
            }

            // two pointers
            // find first char match
            var wordIdx = 0;
            var strIdx = 0;
            while (wordIdx < word.Length)
            {
                if (s[strIdx] != word[wordIdx])
                {
                    wordIdx++;
                    continue;
                }
                else if (s.Length - strIdx > word.Length - wordIdx) break;
                else
                {
                    var fullyMatched = true;
                    var compareIdx = wordIdx + 1;
                    for (var i = strIdx + 1; i < s.Length; i++)
                    {
                        if (s[i] != word[compareIdx])
                        {
                            fullyMatched = false;
                            break;
                        }
                        else compareIdx++;
                    }
                    if (fullyMatched)
                    {
                        result++;
                        break;
                    }
                }
                wordIdx++;
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"a","abc","bc","d"}, "abc", 3],
        [new string[] {"a", "b", "c"}, "aaaaabbbbb", 2],
        [new string[] {"a","a","a"}, "ab", 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string word, int expected)
    {
        var actual = NumOfStrings(input, word);
        Assert.Equal(expected, actual);
    }
}
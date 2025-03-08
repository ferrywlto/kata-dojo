public class Q3456_FindSpecialSubstringOfLengthK
{
    // TC: O(n), n scale with length of s
    // SC: O(k), m scale with unique characters in window k
    public bool HasSpecialSubstring(string s, int k)
    {
        //init for sliding window
        if (k > s.Length) return false;

        var set = new Dictionary<char, int>();
        for (var i = 0; i < k; i++)
        {
            var ch = s[i];
            if (set.TryGetValue(ch, out var val)) set[ch] = ++val;
            else set.Add(ch, 1);
        }

        if (k == s.Length) return set.Count == 1;
        else if (set.Count == 1 && s[k] != s[0]) return true;

        for (var j = 1; j < s.Length - k; j++)
        {
            var before = s[j - 1];
            var current = s[j + k - 1];
            var after = s[j + k];

            set[before]--;
            if (set[before] == 0) set.Remove(before);

            if (set.TryGetValue(current, out var val2)) set[current] = ++val2;
            else set.Add(current, 1);

            if (set.Count == 1 && s[j] != before && s[j] != after) return true;
        }
        var lastCh = s[s.Length - 1 - k];

        set[lastCh]--;
        if (set[lastCh] == 0) set.Remove(lastCh);
        var finalCh = s[s.Length - 1];

        if (set.TryGetValue(finalCh, out var val3)) set[finalCh] = ++val3;
        else set.Add(finalCh, 1);

        return set.Count == 1 && finalCh != lastCh;
    }
    public static TheoryData<string, int, bool> TestData => new()
    {
        {"aaabaaa", 3, true},
        {"abc", 2, false},
        {"abbbc", 3, true},
        {"abbbc", 2, false},
        {"bbbc", 3, true},
        {"abbb", 3, true},
        {"bbbb", 3, false},
        {"bbb", 3, true},
        {"bb", 3, false},
        {"afc", 3, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, bool expected)
    {
        var actual = HasSpecialSubstring(input, k);
        Assert.Equal(expected, actual);
    }
}
public class Q2423_RemoveLetterToEqualizeFrequency
{
    // TC: O(n), n scale with length of word
    // SC: O(m), m scale with distinct frequency count in word
    public bool EqualFrequency(string word)
    {
        var counts = new int[26];
        foreach (var c in word) counts[c - 'a']++;

        var dict = new Dictionary<int, int>();
        foreach (var n in counts)
        {
            if (n == 0) continue;
            if (!dict.TryGetValue(n, out var val)) dict.Add(n, 1);
            else dict[n] = ++val;
        }

        if (dict.Count == 1)
        {
            var x = dict.First();
            return x.Key == 1 || x.Value == 1;
        }
        else if (dict.Count == 2)
        {
            if (dict.TryGetValue(1, out var value) && value == 1) return true;

            var keys = dict.Keys.ToArray();
            if (Math.Abs(keys[0] - keys[1]) == 1)
            {
                var max = Math.Max(keys[0], keys[1]);
                return dict[max] == 1;
            }
            else return false;
        }
        else return false;
    }
    public static List<object[]> TestData =>
    [
        ["zz", true],
        ["abcc", true],
        ["abbcc", true],
        ["aazz", false],
        ["bac", true],
        ["aabbbcccc", false],
        ["abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz", false],
        ["abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzz", true],
        ["aabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzz", false],
        ["a", true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = EqualFrequency(input);
        Assert.Equal(expected, actual);
    }
}

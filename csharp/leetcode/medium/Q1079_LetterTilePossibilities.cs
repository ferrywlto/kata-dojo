using System.Text;

public class Q1079_LetterTilePossibilities
{
    int _result = -1;
    readonly int[] _freq = new int[26];
    readonly HashSet<char> _set = [];

    // TC:  
    public int NumTilePossibilities(string tiles)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < tiles.Length; i++)
        {
            var t = tiles[i];
            _set.Add(t);
            _freq[t - 'A']++;
        }

        BT(sb, tiles.Length);

        return _result;
    }

    private void BT(StringBuilder sb, int maxLen)
    {

        if (sb.Length > maxLen) return;

        _result++;

        foreach (var c in _set)
        {
            var idx = c - 'A';
            if (_freq[idx] == 0) continue;

            sb.Append(c);
            _freq[idx]--;
            BT(sb, maxLen);
            _freq[idx]++;
            sb.Length--;
        }
    }

    public static TheoryData<string, int> TestData => new()
    {
        {"AAB", 8},
        {"AAABBC", 188},
        {"V", 1},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = NumTilePossibilities(input);
        Assert.Equal(expected, actual);
    }
}

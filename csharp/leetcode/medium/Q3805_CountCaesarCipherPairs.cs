using System.Text;

public class Q3805_CountCaesarCipherPairs
{
    // TC: O(n), n scale with length of words
    public long CountPairs(string[] words)
    {
        var result = 0L;

        var ciphersFreq = new Dictionary<string, int>();

        var sb = new StringBuilder();
        foreach (var w in words)
        {
            var firstChar = w[0];
            var diff = firstChar - 'a';
            sb.Append(w);

            for (var i = 0; i < sb.Length; i++)
            {
                var ch = sb[i];
                var asciiCode = ch - 'a'; // a = 0, z = 25
                var x = asciiCode - diff;
                var normalize = (x + 26) % 26;
                var newCh = (char)(normalize + 'a');

                sb[i] = newCh;
            }

            var normalizedWord = sb.ToString();

            if (ciphersFreq.TryGetValue(normalizedWord, out var val))
            {
                result += val;
                ciphersFreq[normalizedWord] = ++val;
            }
            else
            {
                ciphersFreq.Add(normalizedWord, 1);
            }

            sb.Clear();
        }

        return result;
    }
    public static TheoryData<string[], long> TestData => new()
    {
        {["fusion","layout"], 1},
        {["ab","aa","za","aa"], 2},
        {["a","a","a"], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, long expected)
    {
        var actual = CountPairs(input);
        Assert.Equal(expected, actual);
    }
}

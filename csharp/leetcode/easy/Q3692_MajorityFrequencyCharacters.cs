using System.Text;

public class Q3692_MajorityFrequencyCharacters
{
    // TC: O(n), n scale with s.Length
    // SC: O(n), n scale with s.Length
    public string MajorityFrequencyGroup(string s)
    {
        var freq = new int[26];

        var largestFreq = int.MinValue;
        for (var i = 0; i < s.Length; i++)
        {
            var idx = s[i] - 'a';
            freq[idx]++;
            largestFreq = Math.Max(largestFreq, freq[idx]);
        }

        var sizeGroups = new int[s.Length + 1];
        var largestGroupSize = 0;
        var largestGroupIdx = 0;
        for (var i = 0; i < freq.Length; i++)
        {
            if (freq[i] > 0)
            {
                sizeGroups[freq[i]]++;
            }
        }
        for (var j = 0; j < sizeGroups.Length; j++)
        {
            if (sizeGroups[j] >= largestGroupSize)
            {
                largestGroupSize = sizeGroups[j];
                largestGroupIdx = j;
            }
        }

        var sb = new StringBuilder();
        for (var i = 0; i < freq.Length; i++)
        {
            if (freq[i] == largestGroupIdx)
            {
                sb.Append((char)(i + 'a'));
            }
        }
        return sb.ToString();
    }

    public static TheoryData<string, string> TestData =>
        new()
        {
            /*
            0 1 2 3 4
            a b c d e
            3 3 2 4 1
            largest freq = 4
            0 1 2 3 4 5
              1 1 2 1 
            */
            { "aaabbbccdddde", "ab" },
            { "abcd", "abcd" },
            { "pfpfgi", "fp" },
            { "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "f" },
            { "gtcothgttzfqfczthluh", "cfgz" },
            { "esejytaspxcgxqzchgcoeerdimjpmhpnegqsyzdzdsifkbbypp", "bhijmqx" },
            { "asrhyrmzhcehcydmrmce", "chmr" },
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, string expected)
    {
        var result = MajorityFrequencyGroup(s);
        Assert.Equal(expected, result);
    }
}

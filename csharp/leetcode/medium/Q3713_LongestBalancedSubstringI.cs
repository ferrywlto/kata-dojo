public class Q3713_LongestBalancedSubstringI
{
    public int LongestBalanced(string s)
    {
        var longestLen = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var len = 0;
            var distinct = 0;
            var largestOccurrence = 0;
            var mostFreqChar = 0;
            Span<char> freq = new char[26];

            for (var j = i; j < s.Length; j++)
            {
                len++;
                var idx = s[j] - 'a';
                if (freq[idx]++ == 0) distinct++;
                if (freq[idx] > largestOccurrence)
                {
                    largestOccurrence = freq[idx];
                    mostFreqChar = idx;
                }

                // len: 1, maxDist: 1
                // len: 2, maxDist: 2, 2, 1,1
                // len: 3, maxDist: 3, 3, 1,1,1
                // len: 4, maxDist: 4, 2,2, 1,1,1,1
                // len: 5, maxDist: 5, 1,1,1,1,1
                // len: 6, maxDist: 6, 3,3, 2,2,2 1,1,1,1,1,1
            }

            var occuranceRequired = len / distinct;
            var valid = true;
            for (var k = 0; k < freq.Length; k++)
            {
                if(freq[k] > 0 && freq[k] != occuranceRequired)
                {
                    valid = false;
                    break;
                }
            }

            if (valid && len > longestLen) longestLen = len;
        }
        return longestLen;
    }

    private int[] Frequency(string input)
    {

    }

    private bool EvenlyDistributed(int[] input, int requiredOccurance)
    {
        foreach (var n in input)
        {
            if (n != requiredOccurance) return false;
        }

        return true;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "abbac", 4 },
        { "zzabccy", 4 },
        { "aba", 2 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = LongestBalanced(input);
        Assert.Equal(expected, actual);
    }
}

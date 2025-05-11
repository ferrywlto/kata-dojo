public class Q3541_FindMostFrequentVowelAndConsonant
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int MaxFreqSum(string s)
    {
        var charCounts = new int[26];
        var maxCounts = new int[2];

        var vowels = new HashSet<int>() { 0, 4, 8, 14, 20 };
        Console.WriteLine(string.Join(',', vowels));

        for (var i = 0; i < s.Length; i++)
        {
            var idx = s[i] - 'a';
            charCounts[idx]++;
            if (vowels.Contains(idx))
            {
                if (charCounts[idx] > maxCounts[0])
                {
                    maxCounts[0] = charCounts[idx];
                }
            }
            else
            {
                if (charCounts[idx] > maxCounts[1])
                {
                    maxCounts[1] = charCounts[idx];
                }
            }
        }
        return maxCounts[0] + maxCounts[1];
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"successes", 6},
        {"aeiaeia", 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MaxFreqSum(input);
        Assert.Equal(expected, actual);
    }
}
public class Q2609_FindLongestBalancedSubstring
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int FindTheLongestBalancedSubstring(string s)
    {
        var maxLength = 0;
        var counts = new int[2];
        var hasOnes = false;
        int currentLen;

        foreach (var c in s)
        {
            if (c == '0')
            {
                if (hasOnes)
                {
                    currentLen = Math.Min(counts[0], counts[1]) * 2;

                    if (currentLen > maxLength)
                        maxLength = currentLen;

                    counts[0] = 0;
                    counts[1] = 0;
                    hasOnes = false;
                }

                counts[0]++;
            }
            else
            {
                if (!hasOnes) hasOnes = true;
                counts[1]++;
            }
        }
        currentLen = Math.Min(counts[0], counts[1]) * 2;

        if (currentLen > maxLength)
            maxLength = currentLen;
        return maxLength;
    }

    public static TheoryData<string, int> TestData => new()
    {
        {"01000111", 6},
        {"00111", 4},
        {"111", 0},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = FindTheLongestBalancedSubstring(input);
        Assert.Equal(expected, actual);
    }
}
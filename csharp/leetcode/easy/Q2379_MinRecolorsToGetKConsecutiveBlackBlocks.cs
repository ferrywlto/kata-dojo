public class Q2379_MinRecolorsToGetKConsecutiveBlackBlocks
{
    // TC: O(n), n scale with length of blocks
    // SC: O(1), space used does not scale with input
    public int MinimumRecolors(string blocks, int k)
    {
        var white = 0;
        for (var i = 0; i < k; i++)
        {
            if (blocks[i] == 'W') white++;
        }

        var minWhite = white;
        for (var i = k; i < blocks.Length; i++)
        {
            var headIdx = i - k;

            if (blocks[headIdx] == 'W') white--;
            if (blocks[i] == 'W') white++;
            if (white < minWhite) minWhite = white;
        }
        return minWhite;
    }
    public static List<object[]> TestData =>
    [
        ["WBBWWBBWBW", 7, 3],
        ["WBWBBBW", 2, 0],
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, int expected)
    {
        var actual = MinimumRecolors(input, k);
        Assert.Equal(expected, actual);
    }
}

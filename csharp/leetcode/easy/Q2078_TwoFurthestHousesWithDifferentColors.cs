public class Q2078_TwoFurthestHousesWithDifferentColors
{
    // TC: O(n), n scale with length of colors
    // SC: O(1), space used does not scale with input
    public int MaxDistance(int[] colors)
    {
        var first = colors[0]; var firstDiff = -1;
        var last = colors[^1]; var lastDiff = -1;

        if (first != last) return colors.Length - 1;

        for (var i = 1; i <= colors.Length / 2; i++)
        {
            if (colors[i] != last)
            {
                lastDiff = colors.Length - i - 1;
                break;
            }
        }
        for (var j = colors.Length - 1; j >= colors.Length / 2; j--)
        {
            if (colors[j] != first)
            {
                firstDiff = j;
                break;
            }
        }

        return Math.Max(firstDiff, lastDiff);
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,1,1,6,1,1,1}, 3],
        [new int[] {1,8,3,8,3}, 4],
        [new int[] {0,1}, 1],
        [new int[] {4,4,4,11,4,4,11,4,4,4,4,4}, 8],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxDistance(input);
        Assert.Equal(expected, actual);
    }
}

public class Q3206_AlternatingGroupsI
{
    // TC: O(n), n scale with length of colors
    // SC: O(1), space used does not scale with input
    public int NumberOfAlternatingGroups(int[] colors)
    {
        var result = 0;
        var len = colors.Length;
        for (var i = 0; i < len; i++)
        {
            if (i < len - 2)
            {
                if
                (
                    colors[i] != colors[i + 1] &&
                    colors[i] == colors[i + 2]
                ) result++;
            }
            else
            {
                if (
                    colors[i] != colors[(i + 1) % len] &&
                    colors[i] == colors[(i + 2) % len]
                ) result++;
            }
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,1,1], 0},
        {[0,1,0,0,1], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = NumberOfAlternatingGroups(input);
        Assert.Equal(expected, actual);
    }
}

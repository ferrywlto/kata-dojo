public class Q2103_RingsAndRods
{
    // TC: O(n), n scale with length of rings
    // SC: O(1), as space used in dictionary will never exceed 10 items, worst case always 10 entries with a 3 entries hashset 
    public int CountPoints(string rings)
    {
        var rods = new Dictionary<int, HashSet<char>>();
        var result = 0;
        for (var i = 1; i < rings.Length; i += 2)
        {
            var rodId = rings[i];
            var color = rings[i - 1];
            if (rods.TryGetValue(rodId, out var colors))
            {
                if (colors.Count == 3) continue;
                colors.Add(color);
                if (colors.Count == 3) result++;
            }
            else rods.Add(rodId, [color]);
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        ["B0B6G0R6R0R6G9", 1],
        ["B0R0G0R9R0B0G0", 1],
        ["G4", 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountPoints(input);
        Assert.Equal(expected, actual);
    }
}
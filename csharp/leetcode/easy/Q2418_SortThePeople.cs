public class Q2418_SortThePeople
{
    // TC: O(nlogn), n scale with length of names, n log n due to Array.Sort()
    // SC: O(n), n scale with length of names to hold the result
    public string[] SortPeople(string[] names, int[] heights)
    {
        var heightDict = new Dictionary<int, int>();

        // no duplicate height from question constraints.
        for (var i = 0; i < heights.Length; i++)
        {
            heightDict.Add(heights[i], i);
        }

        var result = new string[names.Length];
        Array.Sort(heights);
        // Array.Reverse(heights);

        for (var i = 0; i < heights.Length; i++)
        {
            result[^(i+1)] = names[heightDict[heights[i]]];
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"Mary","John","Emma"}, new int[] {180,165,170}, new string[] {"Mary","Emma","John"}],
        [new string[] {"Alice","Bob","Bob"}, new int[] {155,185,150}, new string[] {"Bob","Alice","Bob"}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int[] heights, string[] expected)
    {
        var actual = SortPeople(input, heights);
        Assert.Equal(expected, actual);
    }
}
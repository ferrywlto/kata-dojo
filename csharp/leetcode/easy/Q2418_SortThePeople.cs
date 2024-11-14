public class Q2418_SortThePeople
{
    public string[] SortPeople(string[] names, int[] heights)
    {
        return [];
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
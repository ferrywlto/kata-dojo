public class Q3206_AlternatingGroupsI
{
    public int NumberOfAlternatingGroups(int[] colors)
    {
        return 0;
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
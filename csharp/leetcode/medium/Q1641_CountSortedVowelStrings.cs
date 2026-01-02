public class Q1641_CountSortedVowelStrings
{
    public int CountVowelStrings(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {1, 5},
        {2, 15},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountVowelStrings(input);
        Assert.Equal(expected, actual);
    }
}

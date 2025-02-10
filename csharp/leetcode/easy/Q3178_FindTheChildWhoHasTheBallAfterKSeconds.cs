public class Q3178_FindTheChildWhoHasTheBallAfterKSeconds
{
    public int NumberOfChild(int n, int k)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {3, 5, 1},
        {5, 6, 2},
        {4, 2, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int k, int expected)
    {
        var actual = NumberOfChild(input, k);
        Assert.Equal(expected, actual);
    }
}
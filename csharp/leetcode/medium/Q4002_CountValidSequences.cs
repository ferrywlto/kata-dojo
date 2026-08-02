public class Q4002_CountValidSequences
{
    public int CountValidSequences(int n, int k) {
        return 0;
    }

    public static TheoryData<int, int, int> TestData => new ()
    {
        {5, 3, 3},
        {3, 2, 2},
        {5, 5, 0},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int k, int expected)
    {
        var actual = CountValidSequences(n, k);
        Assert.Equal(expected, actual);
    }
}

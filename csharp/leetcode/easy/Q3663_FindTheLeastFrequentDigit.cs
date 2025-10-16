public class Q3663_FindTheLeastFrequentDigit
{
    public int GetLeastFrequentDigit(int n)
    {
        return 0;
    }

    public static TheoryData<int, int> TestData => new() { { 1553322, 1 }, { 723344511, 2 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int expected)
    {
        var actual = GetLeastFrequentDigit(n);
        Assert.Equal(expected, actual);
    }
}

public class Q3870_CountCommasInRange
{
    public int CountCommas(int n)
    {
        return 0;
    }

    public static TheoryData<int, int> TestData => new()
    {
        { 1002, 3 }, { 998, 0 }, { 1000, 1 }, { 100000, 1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountCommas(input);
        Assert.Equal(expected, actual);
    }
}

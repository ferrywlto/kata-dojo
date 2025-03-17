public class Q1175_PrimeArrangements
{
    public int NumPrimeArrangements(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {5, 12},
        {100, 682289015},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = NumPrimeArrangements(input);
        Assert.Equal(expected, actual);
    }
}
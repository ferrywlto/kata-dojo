public class Q3918_SumPrimesBetweenNumberAndItsReverse
{
    public int SumOfPrimesInRange(int n)
    {
        return 0;
    }

    public static TheoryData<int, int> TestData => new()
    {
        { 13, 132 },
        { 10, 17 },
        { 8, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SumOfPrimesInRange(input);
        Assert.Equal(expected, actual);
    }
}

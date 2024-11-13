public class Q2413_SmallestEvenMultiple
{
    public int SmallestEvenMultiple(int n)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [5, 10],
        [6, 6],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SmallestEvenMultiple(input);
        Assert.Equal(expected, actual);
    }
}
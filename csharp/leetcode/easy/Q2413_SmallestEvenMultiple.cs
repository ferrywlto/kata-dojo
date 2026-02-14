public class Q2413_SmallestEvenMultiple
{
    // TC: O(1), obviously
    // SC: O(1), obviously
    public int SmallestEvenMultiple(int n)
    {
        return n % 2 == 0 ? n : n * 2;
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

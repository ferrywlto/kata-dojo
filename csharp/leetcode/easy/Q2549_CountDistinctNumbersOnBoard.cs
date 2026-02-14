public class Q2549_CountDistinctNumbersOnBoard
{
    // TC: O(1)
    // SC: O(1)
    public int DistinctIntegers(int n)
    {
        if (n == 1) return 1;
        return n - 1;
    }
    public static List<object[]> TestData =>
    [
        [5,4],
        [3,2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = DistinctIntegers(input);
        Assert.Equal(expected, actual);
    }
}

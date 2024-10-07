public class Q2073_TimeNeededToBuyTickets
{
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {2,3,2}, 2, 6],
        [new int[] {5,1,1,1}, 0, 8],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = TimeRequiredToBuy(input, k);
        Assert.Equal(expected, actual);
    }
}
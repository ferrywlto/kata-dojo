public class Q2073_TimeNeededToBuyTickets
{
    // TC: O(n), n scale with length of tickets
    // SC: O(1), space used does not scale with input 
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        var pointerIdx = k;
        var result = k;
        for (var i = 0; i < k; i++) tickets[i]--;

        while (tickets[k] > 0)
        {
            if (tickets[pointerIdx] > 0)
            {
                tickets[pointerIdx]--;
                result++;
            }
            pointerIdx = (pointerIdx + 1) % tickets.Length;
        }
        return result;
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

class Q1672_RichestCustomerWealth
{
    // TC: O(n), where n is total number of elements in accounts
    // SC: O(1), space used is fixed
    public int MaximumWealth(int[][] accounts)
    {
        var max = 0;
        foreach (var row in accounts)
        {
            var sum = row.Sum();
            if (sum > max) max = sum;
        }
        return max;
    }
}
class Q1672_RichestCustomerWealthTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1,2,3],[3,2,1]}, 6],
        [new int[][] {[1,5],[7,3],[3,5]}, 10],
        [new int[][] {[2,8,7],[7,1,3],[1,9,5]}, 17],
    ];
}
public class Q1672_RichestCustomerWealthTests
{
    [Theory]
    [ClassData(typeof(Q1672_RichestCustomerWealthTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1672_RichestCustomerWealth();
        var acutal = sut.MaximumWealth(input);
        Assert.Equal(expected, acutal);
    }
}

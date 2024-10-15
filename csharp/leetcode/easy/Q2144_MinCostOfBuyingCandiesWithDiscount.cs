public class Q2144_MinCostOfBuyingCandiesWithDiscount
{
    public int MinimumCost(int[] cost) 
    {
        
        return 0;    
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,3}, 5],
        [new int[] {6,5,7,9,2,2}, 23],
        [new int[] {5,5}, 10],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumCost(input);
        Assert.Equal(expected, actual);
    }
}
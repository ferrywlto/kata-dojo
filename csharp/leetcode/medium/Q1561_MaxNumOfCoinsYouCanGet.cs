public class Q1561_MaxNumOfCoinsYouCanGet
{
    public int MaxCoins(int[] piles)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,4,1,2,7,8], 9},
        {[2,4,5], 4},
        {[9,8,7,6,5,1,2,3,4], 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxCoins(input);
        Assert.Equal(expected, actual);
    }
}
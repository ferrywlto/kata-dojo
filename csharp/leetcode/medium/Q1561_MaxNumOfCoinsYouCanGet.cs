public class Q1561_MaxNumOfCoinsYouCanGet
{
    // TC: O(n log n), n scale with length of piles
    // SC: O(1), spaces used does not scale with input
    public int MaxCoins(int[] piles)
    {
        Array.Sort(piles);
        var groups = piles.Length / 3;
        var idx = piles.Length - 2;
        var result = 0;

        for (var i = 0; i < groups; i++)
        {
            result += piles[idx];
            idx -= 2;
        }

        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,4,1,2,7,8], 9},
        {[2,4,5], 4},
        {[9,8,7,6,5,1,2,3,4], 18},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxCoins(input);
        Assert.Equal(expected, actual);
    }
}
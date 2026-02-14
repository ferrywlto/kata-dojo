public class Q1561_MaxNumOfCoinsYouCanGet
{
    // TC: O(n log n), n scale with length of piles
    // SC: O(1), spaces used does not scale with input
    // The solution is, to get the max coins:
    // Alice must get more than you, then we must group two larger numbers together, then get any lowest number for Bob
    // In a sorted array, the max coins you can get will be picking starting the smaller one from every two piles 
    public int MaxCoins(int[] piles)
    {
        Array.Sort(piles);
        var groups = piles.Length / 3;
        var idx = piles.Length - 2;
        var result = 0;

        while (groups > 0)
        {
            result += piles[idx];
            idx -= 2;
            groups--;
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

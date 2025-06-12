public class Q950_RevealCardsInIncreasingOrder
{
    public int[] DeckRevealedIncreasing(int[] deck)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[17,13,11,2,3,5,7], [2,13,3,11,5,17,7]},
        {[1,1000], [1,1000]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = DeckRevealedIncreasing(input);
        Assert.Equal(expected, actual);
    }
}
public class Q950_RevealCardsInIncreasingOrder
{
    // The trick is to reverse the algorithm
    // TC: O(n log n + n^2), dominated by Array.Sort()
    // SC: O(n), for storing result
    public int[] DeckRevealedIncreasing(int[] deck)
    {
        Array.Sort(deck);
        var q = new List<int>() { deck[deck.Length - 1] };
        for (var i = deck.Length - 2; i >= 0; i--)
        {
            var last = q[^1];
            // move the last item to first
            q.RemoveAt(q.Count - 1);
            q.Insert(0, last);
            // add new item at first
            q.Insert(0, deck[i]);
        }
        return q.ToArray();
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

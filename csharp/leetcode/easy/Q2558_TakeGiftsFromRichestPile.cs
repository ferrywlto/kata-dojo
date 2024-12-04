public class Q2558_TakeGiftsFromRichestPile
{
    // TC: O(n log n), n scale with length of gifts, n log n from Array.Sort() * k times, plus n at the end
    // SC: O(1), space used does not scale with input
    public long PickGifts(int[] gifts, int k)
    {
        for (var i = 0; i < k; i++)
        {
            Array.Sort(gifts);
            gifts[^1] = (int)Math.Sqrt(gifts[^1]);
        }
        var total = 0L;
        foreach (var n in gifts) total += n;
        return total;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {25,64,9,4,100}, 4, 29],
        [new int[] {1,1,1,1}, 4, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, long expected)
    {
        var actual = PickGifts(input, k);
        Assert.Equal(expected, actual);
    }
}
public class Q2558_TakeGiftsFromRichestPile
{
    // TC: O((n + k) log n), n scale with length of gifts, n log n from Array.Sort() * k times, plus n at the end
    // SC: O(n), for priority queue
    public long PickGifts(int[] gifts, int k)
    {
        var x = new PriorityQueue<long, long>();
        foreach (var n in gifts) x.Enqueue(n, -n);
        for (var i = 0; i < k; i++)
        {
            var largest = x.Dequeue();
            var sqrt = (int)Math.Sqrt(largest);
            x.Enqueue(sqrt, -sqrt);
        }
        var total = 0L;
        while(x.Count > 0) {
            total += x.Dequeue();
        }
        // foreach (var n in gifts) total += n;
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
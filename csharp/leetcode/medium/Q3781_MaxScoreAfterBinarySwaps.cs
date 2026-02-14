public class Q3781_MaxScoreAfterBinarySwaps
{
    // TC: O(n log n), due to the use of PQ
    // SC: O(n), worst case pq store n - 1 items (last one is one, all others are zeros)
    public long MaximumScore(int[] nums, string s)
    {
        var maxScore = 0L;
        var lastOneIdx = s.LastIndexOf('1');

        var pq = new PriorityQueue<int, int>();

        // The timeout issue is to have a way to keep tracking a PQ of sorted seen top X items 
        // On every step add num to the PQ
        // then if 1 remove the largest value from PQ
        for (var i = 0; i <= lastOneIdx; i++)
        {
            pq.Enqueue(nums[i], -nums[i]);

            if (s[i] == '1')
            {
                var picked = pq.Dequeue();
                maxScore += picked;
            }
        }

        return maxScore;
    }

    public static TheoryData<int[], string, long> TestData => new()
    {
        {[2,1,5,2,3], "01010", 7},
        {[4,7,2,9], "0000", 0},
        {[8,1,7,1,3,7,5,6,10,10], "0010111000", 27},
        {[1,8,8,4,6,2], "110100", 17},
        {[5,6,4,6,10,3,2,2,6], "010010111", 33},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, string score, long expected)
    {
        var actual = MaximumScore(input, score);
        Assert.Equal(expected, actual);
    }
}

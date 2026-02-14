public class Q3780_MaxSumOfThreeNumbersDivisibleByThree
{
    /*
    What to learn here are:
    1. For any triplet sum, only 4 possible combinations:
    - reminder 0 + 0 + 0
    - reminder 1 + 1 + 1
    - reminder 2 + 2 + 2
    - reminder 0 + 1 + 2
    2. (sum of numbers) % 3 = sum (each number % 3)  .
    3. To get the max sum, only need to take care the top values from each bucket. 
    */
    public int MaximumSum(int[] nums)
    {
        var buckets = new Dictionary<int, PriorityQueue<int, int>>();

        foreach (var n in nums)
        {
            var div = n % 3;
            if (buckets.TryGetValue(div, out var bucket))
            {
                bucket.Enqueue(n, -n);
            }
            else
            {
                var pq = new PriorityQueue<int, int>();
                pq.Enqueue(n, -n);
                buckets.Add(div, pq);
            }
        }
        var maxSum = 0;

        if (buckets.TryGetValue(0, out var q0) && q0.Count > 0 &&
            buckets.TryGetValue(1, out var q1) && q1.Count > 0 &&
            buckets.TryGetValue(2, out var q2) && q2.Count > 0
        )
        {
            var sum = q0.Peek() + q1.Peek() + q2.Peek();
            if (sum > maxSum) maxSum = sum;
        }

        if (buckets.TryGetValue(0, out var pq0) && pq0.Count > 2)
        {
            var sum = PqSum(pq0);
            if (sum > maxSum) maxSum = sum;
        }

        if (buckets.TryGetValue(1, out var pq1) && pq1.Count > 2)
        {
            var sum = PqSum(pq1);
            if (sum > maxSum) maxSum = sum;
        }

        if (buckets.TryGetValue(2, out var pq2) && pq2.Count > 2)
        {
            var sum = PqSum(pq2);
            if (sum > maxSum) maxSum = sum;
        }

        return maxSum;
    }

    private int PqSum(PriorityQueue<int, int> pq)
    {
        return pq.Dequeue() + pq.Dequeue() + pq.Dequeue();
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[4,2,3,1], 9},
        {[2,1,5], 0},
        {[2,8,2], 12},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumSum(input);
        Assert.Equal(expected, actual);
    }
}

public class Q2099_FindSubsequenceOfLengthKWithLargestSum
{
    // TC: O(nlogn), n scale with length of nums, adding all to PriorityQueue is n log n.
    // SC: O(k), k scale with k

    // Correct implementation using PriorityQueue
    public int[] MaxSubsequence(int[] nums, int k)
    {
        var pq = new PriorityQueue<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            pq.Enqueue(i, -nums[i]);
        }
        var list = new List<int>();
        while (pq.Count > 0 && list.Count < k)
        {
            list.Add(pq.Dequeue());
        }
        return list
            .OrderBy(x => x)
            .Select(x => nums[x])
            .ToArray();
    }
    // Slower because of array transforming and then sort 
    public int[] MaxSubsequence_Simpler(int[] nums, int k)
    {
        var temp = nums
            .Select((x, idx) => (x, idx))
            .ToArray();

        var comparer = Comparer<(int val, int idx)>
        .Create((a, b) =>
        {
            var result = a.val.CompareTo(b.val);
            // if a == b, return index comparison
            return result == 0
                ? a.idx.CompareTo(b.idx)
                : result;
        });
        Array.Sort(temp, comparer);
        var result = temp[^k..];
        return result
            .OrderBy(x => x.idx)
            .Select(x => x.x)
            .ToArray();
    }
    // example for using SortedSet 
    public int[] MaxSubsequence_SortedSet(int[] nums, int k)
    {
        var comparer = Comparer<(int val, int idx)>
        .Create((a, b) =>
        {
            var result = a.val.CompareTo(b.val);
            // if a == b, return index comparison
            return result == 0
                ? a.idx.CompareTo(b.idx)
                : result;
        });
        var priorityQueue = new SortedSet<(int val, int idx)>(comparer);

        for (var i = 0; i < nums.Length; i++)
        {
            priorityQueue.Add((nums[i], i));
            if (priorityQueue.Count > k)
            {
                priorityQueue.Remove(priorityQueue.Min);
            }
        }

        return priorityQueue
            .OrderBy(x => x.idx)
            .Select(x => x.val)
            .ToArray();
    }
    public static List<object[]> TestData =>
    [
        [new int[]{2,1,3,3}, 2, new int[]{3,3}],
        [new int[]{-1,-2,3,4}, 3, new int[]{-1,3,4}],
        [new int[]{3,4,3,3}, 2, new int[]{4,3}],
        [new int[]{50,-75}, 2, new int[]{50,-75}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int[] expected)
    {
        var actual = MaxSubsequence(input, k);
        Assert.Equal(expected, actual);
    }
}
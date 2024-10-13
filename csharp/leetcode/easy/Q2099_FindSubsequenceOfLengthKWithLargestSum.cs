public class Q2099_FindSubsequenceOfLengthKWithLargestSum
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        var comparer = Comparer<(int val, int idx)>
        .Create((a, b) => {
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
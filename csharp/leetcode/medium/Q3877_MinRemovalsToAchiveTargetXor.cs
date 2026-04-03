public class Q3877_MinRemovalsToAchiveTargetXor
{
    // TC: O(n * U), n scales with length of n, U scales with total distinct XOR
    // SC: O(U)
    public int MinRemovals(int[] nums, int target)
    {
        // solution
        // Due to XOR associative and commutative nature
        // A ^ B ^ C ^ B == A ^ C
        // We can get the XOR of all items first.
        // Then XOR each item again to cancel the effect
        // Which is faster than doing in reverse.
        var len = nums.Length;

        var max = nums[0];
        for (var i = 1; i < len; i++)
            max ^= nums[i];

        if (max == target) return 0;

        var seen = new HashSet<int>();
        var newToProcess = new HashSet<int>();

        for (var i = 0; i < len; i++)
        {
            var xor = max ^ nums[i];
            if (xor == target)
                return 1;
            if (seen.Add(xor))
                newToProcess.Add(xor);
        }
        
        // Use DP to reduce duplicated result, we need to get all unique combinations of Xor results
        // The first hit is minimal removal.
        for (var removed = 2; newToProcess.Count > 0; removed++)
        {
            var next = new HashSet<int>();
            foreach (var n in newToProcess)
            {
                for (var j = 0; j < len; j++)
                {
                    var xor = n ^ nums[j];
                    if (xor == target)
                        return removed;

                    // only process those unseen to prevent re-adding previous calculated ones
                    if (seen.Add(xor))
                        next.Add(xor);
                }
            }

            newToProcess = next;
        }
        return -1;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1, 2, 3], 2, 1 },
        { [2, 4], 2, 1 },
        { [7], 7, 0 },
        { [0, 6], 0, 1 },
        { [6, 12, 5, 14], 3, 2 },
        { [0], 1, -1 },
        { [1], 0, 1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int target, int expected)
    {
        var actual = MinRemovals(input, target);
        Assert.Equal(expected, actual);
    }
}

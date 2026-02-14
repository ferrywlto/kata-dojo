public class Q2529_MaxCountOfPositiveIntegerAndNegativeInteger
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MaximumCount(int[] nums)
    {
        var posCount = 0;
        var negCount = 0;
        foreach (var n in nums)
        {
            if (n < 0) negCount++;
            else if (n > 0) posCount++;
        }
        return Math.Max(posCount, negCount);
    }
    // TC: O(log n)
    // SC: O(1)
    public int MaximumCount_BinarySearch(int[] nums)
    {
        var posCount = 0;
        var negCount = 0;
        var startIdx = 0;
        var endIdx = nums.Length - 1;

        // Log n find how many negative
        while (endIdx - startIdx > 1)
        {
            var middleIdx = (startIdx + endIdx) / 2;
            if (nums[middleIdx] < 0)
            {
                negCount = middleIdx + 1;
                startIdx = middleIdx;
            }
            else
            {
                endIdx = middleIdx;
            }
        }
        if (nums[endIdx] < 0) negCount++;

        startIdx = 0;
        endIdx = nums.Length - 1;
        while (endIdx - startIdx > 1)
        {
            var middleIdx = (startIdx + endIdx) / 2;
            if (nums[middleIdx] > 0)
            {
                posCount = nums.Length - middleIdx;
                endIdx = middleIdx;
            }
            else
            {
                startIdx = middleIdx;
            }
        }
        if (nums[startIdx] > 0) posCount++;

        return Math.Max(posCount, negCount);
    }
    public static List<object[]> TestData =>
    [
        [new int[] {-2,-1,-1,1,2,3}, 3],
        [new int[] {-3,-2,-1,0,0,1,2}, 3],
        [new int[] {5,20,66,1314}, 4],
        [new int[] {-1314, -66, -20, -5}, 4],
        [new int[] {-1314, -66, -20, -5, 1}, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumCount_BinarySearch(input);
        Assert.Equal(expected, actual);
    }
}

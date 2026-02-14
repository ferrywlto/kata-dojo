public class Q3470_MinDistanceBetweenThreeEqualElementsI
{
    // TC: O(n * f * k) where n is the length of nums, f is the frequency of the elements count > 3, k is the number of such elements
    // SC: O(d), where d is the number of distinct elements in nums
    public int MinimumDistance(int[] nums)
    {
        var freq = new int[101];
        var bucket = new Dictionary<int, List<int>>();
        for (var i = 0; i < nums.Length; i++)
        {
            freq[nums[i]]++;
            if (!bucket.ContainsKey(nums[i]))
                bucket[nums[i]] = [];
            bucket[nums[i]].Add(i);
        }

        var minDistance = int.MaxValue;
        for (var j = 1; j < freq.Length; j++)
        {
            if (freq[j] < 3) continue;

            var indices = bucket[j];

            for (var k = 0; k < indices.Count - 2; k++)
            {
                var dist = indices[k + 2] - indices[k] + indices[k + 2] - indices[k + 1] + indices[k + 1] - indices[k];
                minDistance = Math.Min(minDistance, dist);
            }
        }
        return minDistance == int.MaxValue ? -1 : minDistance;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,1,1,3], 6},
        {[1,1,2,3,2,1,2], 8},
        {[1], -1},
        {[1,1,1], 4},
        {[5,3,5,5,5], 4}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestMinimumDistance(int[] nums, int expected)
    {
        var result = MinimumDistance(nums);
        Assert.Equal(expected, result);
    }
}

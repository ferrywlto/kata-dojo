public class Q2395_FindSubarraysWithEqualSum
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique sum from nums
    public bool FindSubarrays(int[] nums)
    {
        var sums = new HashSet<int>();
        var sumCount = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            var sum = nums[i] + nums[i + 1];
            if (!sums.Add(sum))
            {
                sumCount++;
                if (sumCount == 1) return true;
            }
        }
        return false;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,2,4}, true],
        [new int[] {1,2,3,4,5}, false],
        [new int[] {0,0,0}, true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = FindSubarrays(input);
        Assert.Equal(expected, actual);
    }
}

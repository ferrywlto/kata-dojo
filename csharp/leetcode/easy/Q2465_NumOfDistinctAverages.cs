public class Q2465_NumOfDistinctAverages
{
    // TC: O(nlogn), n scale with length of nums, n log n due to Array.Sort()
    // SC: O(n), n scale with distinct average from averaging min and max items rom input repeatly.
    public int DistinctAverages(int[] nums)
    {
        var results = new HashSet<double>();
        Array.Sort(nums);
        var start = 0;
        var end = nums.Length - 1;
        while (start < end)
        {
            var avg = ((double)nums[start] + nums[end]) / 2;
            results.Add(avg);
            start++;
            end--;
        }

        return results.Count;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,1,4,0,3,5}, 2],
        [new int[] {1,100}, 1],
        [new int[] {1,1,1,1}, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = DistinctAverages(input);
        Assert.Equal(expected, actual);
    }
}
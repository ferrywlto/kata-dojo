public class Q2032_TwoOutOfThree
{
    // TC: O(n), where n scale with length of nums1 + length of nums2 + length of nums3 for hash set, then m of their total unique values
    // SC: O(n), where n scale with length of nums1 + length of nums2 + length of nums3 + unique value of all three
    public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
    {
        var result = new Dictionary<int, int>();
        var sets = new HashSet<int>[] { [.. nums1], [.. nums2], [.. nums3] };
        foreach(var set in sets) {
            foreach(var n in set) {
                if (result.TryGetValue(n, out var value)) {
                    result[n] = ++value;
                } else {
                    result.Add(n, 1);
                }
            }
        }
        return result
            .Where(x => x.Value >= 2)
            .Select(x => x.Key)
            .ToList();
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,1,3,2}, new int[] {2,3}, new int[] {3}, new List<int> {2,3}],
        [new int[] {3,1}, new int[] {2,3}, new int[] {1,2}, new List<int> {1,2,3}],
        [new int[] {1,2,2}, new int[] {4,3,3}, new int[] {5}, new List<int>()],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int[] input3, List<int> expected)
    {
        var actual = TwoOutOfThree(input1, input2, input3);
        Assert.Equal(expected, actual);
    }
}
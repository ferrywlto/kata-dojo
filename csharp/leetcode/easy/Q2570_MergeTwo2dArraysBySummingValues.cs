public class Q2570_MergeTwo2dArraysBySummingValues
{
    // TC: O(n log n), n scale with total length of nums1 and nums2, then do another n to add into result, n log n due to OrderBy()
    // SC: O(m), m scale with unique ids in both nums1 and nums2
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        var dict = new Dictionary<int, int>();
        foreach (var p in nums1)
        {
            dict.Add(p[0], p[1]);
        }
        foreach (var p in nums2)
        {
            if (dict.TryGetValue(p[0], out var val))
            {
                dict[p[0]] = val + p[1];
            }
            else dict.Add(p[0], p[1]);
        }

        var result = new List<int[]>();
        var keys = dict.Keys.OrderBy(x => x);
        foreach (var key in keys)
        {
            result.Add([key, dict[key]]);
        }
        return result.ToArray();
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][] {[1,2],[2,3],[4,5]},
            new int[][] {[1,4],[3,2],[4,1]},
            new int[][] {[1,6],[2,3],[3,2],[4,6]},
        ],
        [
            new int[][] {[2,4],[3,6],[5,5]},
            new int[][] {[1,3],[4,3]},
            new int[][] {[1,3],[2,4],[3,6],[4,3],[5,5]},
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input1, int[][] input2, int[][] expected)
    {
        var actual = MergeArrays(input1, input2);
        Assert.Equal(expected, actual);
    }
}
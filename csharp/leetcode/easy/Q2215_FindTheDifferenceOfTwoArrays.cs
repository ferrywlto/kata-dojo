public class Q2215_FindTheDifferenceOfTwoArrays
{
    // TC: O(n + m), n scale with length of nums1, m scale with length of nums2
    // SC: O(j + k), j scale with unique numbers of nums1 and k scale with unique numbers of nums2 for the hash sets
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        var result = new List<IList<int>>
        {
            ([]),
            ([])
        };

        var set1 = nums1.ToHashSet();
        var set2 = nums2.ToHashSet();
        foreach (var n in set1)
        {
            if (!set2.Contains(n)) result[0].Add(n);
        }
        foreach (var n in set2)
        {
            if (!set1.Contains(n)) result[1].Add(n);
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [
            new int[] {1,2,3},
            new int[] {2,4,6},
            new List<IList<int>>
            {
                new List<int> {1,3},
                new List<int> {4,6},
            },
        ],
        [
            new int[] {1,2,3,3},
            new int[] {1,1,2,2},
            new List<IList<int>>
            {
                new List<int> { 3 },
                new List<int>()
            },
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, IList<IList<int>> expected)
    {
        var actual = FindDifference(input1, input2);
        Assert.Equal(expected, actual);
    }
}
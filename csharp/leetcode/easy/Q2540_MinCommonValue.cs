public class Q2540_MinCommonValue
{
    // TC: O(n), n scale with total elements in both nums1 and nums2
    // SC: O(1), space used does not scale with input
    public int GetCommon(int[] nums1, int[] nums2)
    {
        var set = new HashSet<int>(nums1);
        var minCommon = int.MaxValue;
        foreach (var n in nums2)
        {
            if (set.Contains(n))
            {
                if (n < minCommon)
                {
                    minCommon = n;
                }
            }
        }
        return minCommon == int.MaxValue ? -1 : minCommon;
    }
    // TC: O(n), same time in worst case that is no common values, but in best case it returns as soon as a common is found.
    public int GetCommon_TwoPointers(int[] nums1, int[] nums2)
    {
        var idx1 = 0;
        var idx2 = 0;

        while (idx1 < nums1.Length && idx2 < nums2.Length)
        {
            if (nums1[idx1] == nums2[idx2])
            {
                return nums1[idx1];
            }
            else if (nums1[idx1] > nums2[idx2])
            {
                idx2++;
            }
            else idx1++;
        }

        return -1;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,3}, new int[] {2,4}, 2],
        [new int[] {1,2,3,6}, new int[] {2,3,4,5}, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = GetCommon_TwoPointers(input1, input2);
        Assert.Equal(expected, actual);
    }
}

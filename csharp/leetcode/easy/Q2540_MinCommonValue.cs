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
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,3}, new int[] {2,4}, 2],
        [new int[] {1,2,3,6}, new int[] {2,3,4,5}, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = GetCommon(input1, input2);
        Assert.Equal(expected, actual);
    }
}

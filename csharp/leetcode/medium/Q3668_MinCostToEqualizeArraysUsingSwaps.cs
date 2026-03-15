public class Q3668_MinCostToEqualizeArraysUsingSwaps
{
    public int MinCost(int[] nums1, int[] nums2)
    {
        return 0;
    }

    public static TheoryData<int[], int[], int> TestData => new()
    {
        { [10, 20], [20, 10], 0 }, { [10, 10], [20, 20], 1 }, { [10, 20], [30, 40], -1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums1, int[] nums2, int expected)
    {
        var actual = MinCost(nums1, nums2);
        Assert.Equal(expected, actual);
    }
}

public class Q3131_FindIntegerAddedArrayI
{
    // TC: O(n), n scale with length of nums1
    // SC: O(1), space used does not scale with input
    public int AddedInteger(int[] nums1, int[] nums2)
    {
        var sum1 = 0;
        var sum2 = 0;
        for (var i = 0; i < nums1.Length; i++)
        {
            sum1 += nums1[i];
            sum2 += nums2[i];
        }

        return (sum2 - sum1) / nums1.Length;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {
        {[2,6,4], [9,7,5], 3},
        {[10], [5], -5},
        {[1,1,1,1], [1,1,1,1], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = AddedInteger(input1, input2);
        Assert.Equal(expected, actual);
    }
}

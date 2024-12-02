public class Q2540_MinCommonValue
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,3}, new int[] {2,4}],
        [new int[] {1,2,3,6}, new int[] {2,3,4,5}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = GetCommon(input1, input2);
        Assert.Equal(expected, actual);
    }
}

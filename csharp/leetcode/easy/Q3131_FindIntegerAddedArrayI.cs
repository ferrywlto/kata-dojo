public class Q3131_FindIntegerAddedArrayI
{
    public int AddedInteger(int[] nums1, int[] nums2)
    {
        return 0;
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
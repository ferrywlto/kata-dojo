public class Q2956_FindCommonElementsBetweenTwoArrays
{
    public int[] FindIntersectionValues(int[] nums1, int[] nums2)
    {
        return [];
    }
    public static TheoryData<int[], int[], int[]> TestData => new()
    {
        {[2,3,2], [1,2], [2,1]},
        {[4,3,2,3,1], [2,2,5,2,3,6], [3,4]},
        {[3,4,2,3], [1,5], [0,0]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int[] expected)
    {
        var actual = FindIntersectionValues(input1, input2);
        Assert.Equal(expected, actual);
    }

}

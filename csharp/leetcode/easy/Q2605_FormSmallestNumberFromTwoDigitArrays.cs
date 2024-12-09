public class Q2605_FormSmallestNumberFromTwoDigitArrays
{
    public int MinNumber(int[] nums1, int[] nums2)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,1,3}, new int[] {5,7}, 15],
        [new int[] {3,5,2,6}, new int[] {3,1,7}, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = MinNumber(input1, input2);
        Assert.Equal(expected, actual);
    }
}
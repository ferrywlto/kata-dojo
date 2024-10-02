public class Q2032_TwoOutOfThree
{
    public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,1,3,2}, new int[] {2,3}, new int[] {3}, new List<int> {2,3}],
        [new int[] {3,1}, new int[] {2,3}, new int[] {1,2}, new List<int> {1,2,3}],
        [new int[] {1,2,2}, new int[] {4,3,3}, new int[] {5}, new List<int>()],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int[] input3, List<int> expected)
    {
        var actual = TwoOutOfThree(input1, input2, input3);
        Assert.Equal(expected, actual);
    }
}
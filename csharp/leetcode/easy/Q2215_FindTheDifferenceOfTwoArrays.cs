public class Q2215_FindTheDifferenceOfTwoArrays
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [
            new int[] {1,2,3},
            new int[] {2,4,6},
            new List<List<int>>
            {
                new() {1,3},
                new() {4,6},
            }
        ],
        [
            new int[] {1,2,3,3},
            new int[] {1,1,2,2},
            new List<List<int>> { new() { 3 },new() {}}
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, List<List<int>> expected)
    {
        var actual = FindDifference(input1, input2);
        Assert.Equal(expected, actual);
    }
}
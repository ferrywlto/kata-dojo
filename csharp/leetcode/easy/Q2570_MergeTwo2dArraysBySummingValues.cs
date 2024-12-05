public class Q2570_MergeTwo2dArraysBySummingValues
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][] {[1,2],[2,3],[4,5]},
            new int[][] {[1,4],[3,2],[4,1]},
            new int[][] {[1,6],[2,3],[3,2],[4,6]},
        ],
        [
            new int[][] {[2,4],[3,6],[5,5]},
            new int[][] {[1,3],[4,3]},
            new int[][] {[1,3],[2,4],[3,6],[4,3],[5,5]},
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input1, int[][] input2, int[][] expected)
    {
        var actual = MergeArrays(input1, input2);
        Assert.Equal(expected, actual);
    }
}
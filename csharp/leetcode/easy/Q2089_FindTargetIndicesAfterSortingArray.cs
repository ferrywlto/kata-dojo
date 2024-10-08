public class Q2089_FindTargetIndicesAfterSortingArray
{
    public IList<int> TargetIndices(int[] nums, int target)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,5,2,3}, 2, new List<int> {1,2}],
        [new int[] {1,2,5,2,3}, 3, new List<int> {3}],
        [new int[] {1,2,5,2,3}, 5, new List<int> {4}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int target, List<int> expected)
    {
        var actual = TargetIndices(input, target);
        Assert.Equal(expected, actual);
    }
}
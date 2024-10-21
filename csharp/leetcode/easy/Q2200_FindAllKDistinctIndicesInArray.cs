public class Q2200_FindAllKDistinctIndicesInArray
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {3,4,9,1,3,9,5}, 9, 1, new int[] {1,2,3,4,5,6}],
        [new int[] {2,2,2,2,2}, 2, 2, new int[] {0,1,2,3,4}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int key, int k, int[] expected)
    {
        var actual = FindKDistantIndices(input, key, k);
        Assert.Equal(expected, actual);
    }
}
public class Q2363_MergeSimilarItems
{
    public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][] { [1,1],[4,5],[3,8] },
            new int[][] { [3,1],[1,5] },
            new List<IList<int>>()
            {
                new List<int>(){ 1,6 },
                new List<int>(){ 3,9 },
                new List<int>(){ 4,5 },
            }
        ],
        [
            new int[][] { [1,1],[3,2],[2,3] },
            new int[][] { [2,1],[3,2],[1,3] },
            new List<IList<int>>()
            {
                new List<int>(){ 1,4 },
                new List<int>(){ 2,4 },
                new List<int>(){ 3,4 },
            }
        ],
        [
            new int[][] { [1,3],[2,2] },
            new int[][] { [7,1],[2,2],[1,4] },
            new List<IList<int>>()
            {
                new List<int>(){ 1,7 },
                new List<int>(){ 2,4 },
                new List<int>(){ 7,1 },
            }
        ],                
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] items1, int[][] items2, List<IList<int>> expected)
    {
        var actual = MergeSimilarItems(items1, items2);
        Assert.Equal(expected, actual);
    }
}
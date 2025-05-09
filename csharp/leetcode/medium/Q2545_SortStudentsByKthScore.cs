public class Q2545_SortStudentsByKthScore
{
    // TC: O(n log n), n scale with length of score
    // SC: O(n)
    public int[][] SortTheStudents(int[][] score, int k)
    {
        var len = score.Length;
        var originalIdx = new Dictionary<int, int>();
        var toSort = new int[len];
        for (var row = 0; row < len; row++)
        {
            var item = score[row][k];
            originalIdx.Add(item, row);
            toSort[row] = item;
        }

        Array.Sort(toSort);
        Array.Reverse(toSort);

        var result = new int[len][];
        for (var newIdx = 0; newIdx < toSort.Length; newIdx++)
        {
            result[newIdx] = score[originalIdx[toSort[newIdx]]];
        }
        return result;
    }
    public static TheoryData<int[][], int, int[][]> TestData => new(){
        {[[10,6,9,1],[7,5,11,2],[4,8,3,15]], 2, [[7,5,11,2],[10,6,9,1],[4,8,3,15]]},
        {[[3,4],[5,6]], 0, [[5,6],[3,4]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int k, int[][] expected)
    {
        var actual = SortTheStudents(input, k);
        Assert.Equal(expected, actual);
    }
}
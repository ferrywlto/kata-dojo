public class Q2545_SortStudentsByKthScore
{
    public int[][] SortTheStudents(int[][] score, int k)
    {
        return [];
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
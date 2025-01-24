public class Q2965_FindMissingAndRepeatedValues
{
    // TC: O(n), n scale with total numbers in grid
    // SC: O(n), same as time as all numbers are unique
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        var len = grid.Length;
        var sumExpected = (1 + (len * len)) * len * len / 2;
        var sumActual = 0;
        var duplicate = 0;
        var set = new HashSet<int>();
        foreach (var row in grid)
        {
            foreach (var n in row)
            {
                if (!set.Add(n)) duplicate = n;
                else sumActual += n;
            }
        }

        return [duplicate, sumExpected - sumActual];
    }
    public static TheoryData<int[][], int[]> TestData => new()
    {
        {[[1,3],[2,2]], [2,4]},
        {[[9,1,7],[8,9,2],[3,4,6]], [9,5]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[] expected)
    {
        var actual = FindMissingAndRepeatedValues(input);
        Assert.Equal(expected, actual);
    }
}
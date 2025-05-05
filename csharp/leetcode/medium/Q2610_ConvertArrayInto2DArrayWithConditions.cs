public class Q2610_ConvertArrayInto2DArrayWithConditions
{
    public IList<IList<int>> FindMatrix(int[] nums)
    {
        
        return [];
    }
    public static TheoryData<int[], List<List<int>>> TestData => new()
    {
        {
            [1,3,4,1,2,3,1],
            [[1,3,4,2],[1,3],[1]]
        },
        {
            [1,2,3,4],
            [[4,3,2,1]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<List<int>> expected)
    {
        var actual = FindMatrix(input);
        Assert.Equal(expected, actual);
    }
}
public class Q2248_IntersectionOfMultipleArrays
{
    public IList<int> Intersection(int[][] nums)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [3,1,2,4,5],
                [1,2,3,4],
                [3,4,5,6],
            },
            new List<int> {3,4}
        ],
        [
            new int[][]
            {
                [1,2,3],
                [4,5,6],
            },
            new List<int> {}
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, List<int> expected)
    {
        var actual = Intersection(input);
        Assert.Equal(expected, actual);
    }
}
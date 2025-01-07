public class Q2848_PointsThatIntersectWithCars
{
    public int NumberOfPoints(IList<IList<int>> nums)
    {
        return 0;
    }
    public static TheoryData<IList<IList<int>>, int> TestData => new()
    {
        {
            new List<IList<int>>()
            {
                new List<int>{3,6},
                new List<int>{1,5},
                new List<int>{4,7},
            }, 7
        },
        {
            new List<IList<int>>()
            {
                new List<int>{1,3},
                new List<int>{5,8},
            }, 7
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(IList<IList<int>> input, int expected)
    {
        var actual = NumberOfPoints(input);
        Assert.Equal(expected, actual);
    }
}
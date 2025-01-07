public class Q2848_PointsThatIntersectWithCars
{
    // TC: O(n), n scale with total sum of range in nums
    // SC: O(m), m scale with unique number in all range 
    public int NumberOfPoints(IList<IList<int>> nums)
    {
        var set = new HashSet<int>();
        foreach (var pair in nums)
        {
            var start = pair[0];
            var end = pair[1];
            for (var i = start; i <= end; i++)
            {
                set.Add(i);
            }
        }

        return set.Count;
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
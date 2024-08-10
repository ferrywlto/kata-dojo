class Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints
{
    // TC: O(nlogn), where n is the number of points + nlogn for Array.Sort() + m length of filtered, dominated by nlogn
    // SC: O(n), where n is the number of unique number in the first element of each pair in points 
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        var filtered = points.Select(x => x[0]).Distinct().ToList();
        filtered.Sort();
        var maxDiff = 0;
        for (var i = 1; i < filtered.Count; i++)
        {
            var temp = filtered[i] - filtered[i - 1];
            if (temp > maxDiff) maxDiff = temp;
        }
        return maxDiff;
    }
}
class Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPointsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [8,7],[9,9],[7,4],[9,7]
            }, 1
        ],
        [
            new int[][]
            {
                [3,1],[9,0],[1,0],[1,4],[5,3],[8,8]
            }, 3
        ]
    ];
}
public class Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPointsTests
{
    [Theory]
    [ClassData(typeof(Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPointsTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints();
        var actual = sut.MaxWidthOfVerticalArea(input);
        Assert.Equal(expected, actual);
    }
}
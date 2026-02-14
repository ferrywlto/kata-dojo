class Q1725_NumOfRectanglesCanFormLargestSquare
{
    // TC: O(n), where n is length of rectangles
    // SC: O(m), where m is unique square size
    public int CountGoodRectangles(int[][] rectangles)
    {
        var dict = new Dictionary<int, int>();
        var max = int.MinValue;
        foreach (var rect in rectangles)
        {
            var min = Math.Min(rect[0], rect[1]);
            if (dict.TryGetValue(min, out var value))
                dict[min] = ++value;
            else
                dict.Add(min, 1);

            if (min > max) max = min;
        }
        return dict[max];
    }
}
class Q1725_NumOfRectanglesCanFormLargestSquareTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[5,8],[3,9],[5,12],[16,5]}, 3],
        [new int[][] {[2,3],[3,7],[4,3],[3,7]}, 3],
    ];
}
public class Q1725_NumOfRectanglesCanFormLargestSquareTests
{
    [Theory]
    [ClassData(typeof(Q1725_NumOfRectanglesCanFormLargestSquareTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1725_NumOfRectanglesCanFormLargestSquare();
        var actual = sut.CountGoodRectangles(input);
        Assert.Equal(expected, actual);
    }
}

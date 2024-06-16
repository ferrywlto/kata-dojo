class Q1200_MinimumAbsoluteDifference
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        return [];
    }
}
class Q1200_MinimumAbsoluteDifferenceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{4,2,1,3}, new List<List<int>>{ new() {1, 2},new() {2, 3}, new() {3, 4}}],
        [new int[]{1,3,6,10,15}, new List<List<int>> { new() { 1, 3 } }],
        [new int[]{3,8,-10,23,19,-4,-14,27}, new List<List<int>> { new() { -14, -10 }, new() { 19, 23 }, new() { 23, 27 }}],
    ];
}

public class Q1200_MinimumAbsoluteDifferenceTests
{
    [Theory]
    [ClassData(typeof(Q1200_MinimumAbsoluteDifferenceTestData))]
    public void OfficialTestCases(int[] input, List<List<int>> expected)
    {
        var sut = new Q1200_MinimumAbsoluteDifference();
        var actual = sut.MinimumAbsDifference(input);
        Assert.Equal(expected, actual);
    }
}
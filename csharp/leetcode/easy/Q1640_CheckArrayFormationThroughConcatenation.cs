class Q1640_CheckArrayFormationThroughConcatenation
{
    public bool CanFormArray(int[] arr, int[][] pieces)
    {
        return false;
    }
}
class Q1640_CheckArrayFormationThroughConcatenationTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {15,88}, new int[][] {[88],[15]}],
        [new int[] {49,18,16}, new int[][] {[16,18,49]}],
        [new int[] {91,4,64,78}, new int[][] {[78],[4,64],[91]}],
    ];
}
public class Q1640_CheckArrayFormationThroughConcatenationTests
{
    [Theory]
    [ClassData(typeof(Q1640_CheckArrayFormationThroughConcatenationTestData))]
    public void OfficialTestCases(int[] input, int[][] pieces, bool expected)
    {
        var sut = new Q1640_CheckArrayFormationThroughConcatenation();
        var actual = sut.CanFormArray(input, pieces);
        Assert.Equal(expected, actual);
    }
}
class Q1128_NumberOfEquivalentDominoPairs
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        return 0;
    }
}
class Q1128_NumberOfEquivalentDominoPairsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][]{[1,2],[2,1],[3,4],[5,6]}, 1],
        [new int[][]{[1,2],[1,2],[1,1],[1,2],[2,2]}, 3],
    ];
}
public class Q1128_NumberOfEquivalentDominoPairsTests
{
    [Theory]
    [ClassData(typeof(Q1128_NumberOfEquivalentDominoPairsTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1128_NumberOfEquivalentDominoPairs();
        var actual = sut.NumEquivDominoPairs(input);
        Assert.Equal(expected, actual);
    }
}
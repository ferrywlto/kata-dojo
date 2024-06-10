class Q1128_NumberOfEquivalentDominoPairs
{
    // TC: O(n^2), (n*(n+1))/2 where n is number of dominoes
    // SC: O(1)
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        var pairs = 0;
        for(var i=0; i<dominoes.Length-1; i++)
        {
            var p = dominoes[i];
            for (var j = i + 1; j < dominoes.Length; j++)
            {
                if (
                    (dominoes[j][0] == p[0] && dominoes[j][1] == p[1]) ||
                    (dominoes[j][0] == p[1] && dominoes[j][1] == p[0])
                ) pairs++;
            }
        }
        return pairs;
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
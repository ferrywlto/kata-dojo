
class Q997_FindTheTownJudge
{
    public int FindJudge(int n, int[][] trust)
    {
        return 0;
    }
}

class Q997_FindTheTownJudgeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [2, new int[][]{[1,2]}, 2],
        [3, new int[][]{[1,3],[2,3]}, 3],
        [3, new int[][]{[1,3],[2,3],[3,1]}, -1],
    ];
}

public class Q997_FindTheTownJudgeTests
{
    [Theory]
    [ClassData(typeof(Q997_FindTheTownJudgeTestData))]
    public void OfficialTestCases(int input, int[][] trust, int expected)
    {
        var sut = new Q997_FindTheTownJudge();
        var actual = sut.FindJudge(input, trust);
        Assert.Equal(expected, actual);
    }
}
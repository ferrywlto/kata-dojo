class Q1496_PathCrossing
{
    // TC: O(n), where n is the length of path string
    // SC: O(n), worst case path never cross itselt thus holding all steps
    public bool IsPathCrossing(string path)
    {
        var set = new HashSet<(int x, int y)>() { (0, 0) };
        var x = 0;
        var y = 0;

        foreach (var c in path)
        {
            switch (c)
            {
                case 'N': y++; break;
                case 'S': y--; break;
                case 'E': x++; break;
                case 'W': x--; break;
            }
            if (set.Contains((x, y))) return true;
            else set.Add((x, y));
        }
        return false;
    }
}
class Q1496_PathCrossingTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["NES", false],
        ["EESWN", true],
        ["NNSWWEWSSESSWENNW", true],
        ["NESWW", true],
    ];
}
public class Q1496_PathCrossingTests
{
    [Theory]
    [ClassData(typeof(Q1496_PathCrossingTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1496_PathCrossing();
        var actual = sut.IsPathCrossing(input);
        Assert.Equal(expected, actual);
    }
}
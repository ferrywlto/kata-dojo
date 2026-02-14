class Q771_JewelsAndStones
{
    // TC: O(j+s)
    // SC: O(j)
    public int NumJewelsInStones(string jewels, string stones)
    {
        var jDict = new Dictionary<char, int>();
        foreach (var j in jewels) jDict.Add(j, 0);

        var count = 0;
        foreach (var s in stones)
        {
            if (jDict.ContainsKey(s)) count++;
        }
        return count;
    }
}

class Q771_JewelsAndStonesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["aA", "aAAbbbb", 3],
        ["z", "ZZ", 0],
    ];
}

public class Q771_JewelsAndStonesTests
{
    [Theory]
    [ClassData(typeof(Q771_JewelsAndStonesTestData))]
    public void OfficialTestCases(string jewels, string stones, int expected)
    {
        var sut = new Q771_JewelsAndStones();
        var actual = sut.NumJewelsInStones(jewels, stones);
        Assert.Equal(expected, actual);
    }
}

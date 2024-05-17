
class Q942_DIStringMatch
{
    public int[] DiStringMatch(string s)
    {
        return [];
    }
}

class Q942_DIStringMatchTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["IDID", new int[] {0,4,1,3,2}],
        ["III", new int[] {0,1,2,3}],
        ["DDI", new int[] {3,2,0,1}],
    ];
}

public class Q942_DIStringMatchTests
{
    [Theory]
    [ClassData(typeof(Q942_DIStringMatchTestData))]
    public void OfficialTestCases(string input, int[] expected)
    {
        var sut = new Q942_DIStringMatch();
        var actual = sut.DiStringMatch(input);
        Assert.Equal(expected, actual);
    }
}
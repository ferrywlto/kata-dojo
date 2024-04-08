
namespace dojo.leetcode;

public class Q830_PositionsOfLargeGroups
{
    public IList<IList<int>> LargeGroupPositions(string s)
    {
        return [];
    }
}

public class Q830_PositionsOfLargeGroupsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["abbxxxxzzy", new int[][] {[3,6]}],
        ["abc", new int[][] {[]}],
        ["abcdddeeeeaabbbcd", new int[][] {[3,5],[6,9],[12,14]}],
    ];
}

public class Q830_PositionsOfLargeGroupsTests
{
    [Theory]
    [ClassData(typeof(Q830_PositionsOfLargeGroupsTestData))]
    public void OfficialTestCases(string input, int[][] expected)
    {
        var sut = new Q830_PositionsOfLargeGroups();
        var actual = sut.LargeGroupPositions(input);
        Assert.Equal(expected, actual);
    }
}
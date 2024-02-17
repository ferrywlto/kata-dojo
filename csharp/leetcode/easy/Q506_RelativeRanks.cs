namespace dojo.leetcode;

public class Q506_RelativeRanks
{
    public string[] FindRelativeRanks(int[] score)
    {
        return [];
    }
}

public class Q506_RelativeRanksTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {5, 4, 3, 2, 1}, new string[] {"Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"}],
        [new int[] {10, 3, 8, 9, 4}, new string[] {"Gold Medal", "5", "Bronze Medal", "Silver Medal", "4"}]
    ];
}

public class Q506_RelativeRanksTests
{
    [Theory]
    [ClassData(typeof(Q506_RelativeRanksTestData))]
    public void OfficialTestCases(int[] score, string[] expected)
    {
        var sut = new Q506_RelativeRanks();
        var actual = sut.FindRelativeRanks(score);
        Assert.Equal(expected, actual);
    }
}
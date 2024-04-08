namespace dojo.leetcode;

public class Q830_PositionsOfLargeGroups
{
    // TC: O(n), n is length of s
    // SC: O(n), n is num of groups found, O(1) if not count the space to store the result
    public IList<IList<int>> LargeGroupPositions(string s)
    {
        char lastChar = (char)0;
        var startIdx = 0;
        var endIdx = 0;
        var result = new List<List<int>>();
        for (var i = 0; i < s.Length; i++)
        {
            if (i > 0)
            {
                if (s[i] != lastChar)
                {
                    if (endIdx - startIdx + 1 >= 3)
                        result.Add([startIdx, endIdx]);
                    startIdx = i;
                    endIdx = i;
                    lastChar = s[i];
                }
                else
                {
                    endIdx = i;
                }
            }
            else
            {
                startIdx = i;
                endIdx = i;
                lastChar = s[i];
            }
        }
        if (endIdx - startIdx + 1 >= 3)
            result.Add([startIdx, endIdx]);

        return result.Cast<IList<int>>().ToList(); ;
    }
}

public class Q830_PositionsOfLargeGroupsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["abbxxxxzzy", new List<List<int>> { new() { 3, 6 } }],
        ["abc", new List<List<int>>()],
        ["abcdddeeeeaabbbcd", new List<List<int>> { new () {3,5}, new() {6,9}, new(){12,14}}],
        ["aabca", new List<List<int>>()],
        ["aaabca", new List<List<int>> { new() {0,2} }],
        ["aabcaaa", new List<List<int>> { new() {4,6} }],
    ];
}

public class Q830_PositionsOfLargeGroupsTests
{
    [Theory]
    [ClassData(typeof(Q830_PositionsOfLargeGroupsTestData))]
    public void OfficialTestCases(string input, List<List<int>> expected)
    {
        var sut = new Q830_PositionsOfLargeGroups();
        var actual = sut.LargeGroupPositions(input);
        Assert.Equal(expected, actual);
    }
}
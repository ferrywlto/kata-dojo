namespace dojo.leetcode;

public class Q506_RelativeRanks
{
    // TC: O(n^2), SC: O(n)
    public string[] FindRelativeRanks(int[] score)
    {
        int[] copy = new int[score.Length];
        Array.Copy(score, copy, score.Length);
        Array.Sort(copy);
        Array.Reverse(copy);
        var result = new string[score.Length];

        for(var i=0; i<score.Length; i++)
        {
            var idx = Array.IndexOf(copy, score[i]);
            if (idx == 0) result[i] = "Gold Medal";
            else if (idx == 1) result[i] = "Silver Medal";
            else if (idx == 2) result[i] = "Bronze Medal";
            else result[i] = (idx+1).ToString();
        }
        return result;
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
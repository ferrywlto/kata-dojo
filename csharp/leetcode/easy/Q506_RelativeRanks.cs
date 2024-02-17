namespace dojo.leetcode;

public class ReverseComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        // Reverse the order of comparison to sort in descending order
        return y.CompareTo(x);
    }
}

public class Q506_RelativeRanks
{
    // TC: O(n log n), SC: O(n)
    public string[] FindRelativeRanks(int[] score)
    {
        int[] copy = (int[])score.Clone();
        Array.Sort(copy, (a,b) => b.CompareTo(a));
        
        var rank = new Dictionary<int, string>();
        for(var i=0; i<copy.Length; i++)
        {
            if(i == 0) 
                rank.Add(copy[i], "Gold Medal");
            else if (i == 1) 
                rank.Add(copy[i], "Silver Medal");
            else if (i == 2)
                rank.Add(copy[i], "Bronze Medal");
            else
                rank.Add(copy[i], (i+1).ToString());
        }
        return score.Select(x => rank[x]).ToArray();
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
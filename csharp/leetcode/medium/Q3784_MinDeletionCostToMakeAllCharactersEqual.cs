public class Q3784_MinDeletionCostToMakeAllCharactersEqual
{
    // TC: O(n), n scale with length of s
    // SC: O(c), c scale with number of unique characters in s
    public long MinCost(string s, int[] cost)
    {
        var costDict = new Dictionary<char, long>();
        var largestChar = '\n';
        var largestBucketSize = 0L;

        var totalCost = 0L;
        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (costDict.TryGetValue(c, out var bucketCost))
            {
                costDict[c] = bucketCost + cost[i];
            }
            else
            {
                costDict.Add(c, cost[i]);
            }
            totalCost += cost[i];

            if (costDict[c] > largestBucketSize)
            {
                largestBucketSize = costDict[c];
                largestChar = c;
            }
        }
        return totalCost - costDict[largestChar];
    }
    public static TheoryData<string, int[], long> TestData => new()
    {
        {"aabaac", [1,2,3,4,1,10], 11},
        {"abc", [10,5,8], 13},
        {"zzzzz", [67,67,67,67,67], 0},
        {"mjvuu", [728052804,796037807,668485422,572545092,223318586], 2192401904},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int[] cost, long expected)
    {
        var actual = MinCost(input, cost);
        Assert.Equal(expected, actual);
    }
}

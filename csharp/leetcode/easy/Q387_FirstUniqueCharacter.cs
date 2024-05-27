class Q387_FirstUniqueCharacter
{
    // TC: O(n), SC: O(n)
    public int FirstUniqChar(string s) 
    {
        var dict = new Dictionary<char, CharInfo>();
     
        for (var i=0; i<s.Length; i++)
        {
            if (dict.TryGetValue(s[i], out CharInfo? info))
            {
                dict[s[i]] = info with { Count = info.Count+1 };
            }
            else 
            {
                dict.Add(s[i], new CharInfo(i,1));
            }
        }

        var minIdx = int.MaxValue;
        foreach (var kvp in dict)
        {
            if (kvp.Value.Count == 1 && kvp.Value.FisrtSeenIdx < minIdx)
            {
                minIdx = kvp.Value.FisrtSeenIdx;
            }
        }
        return minIdx == int.MaxValue ? -1 : minIdx;
    }
    record CharInfo(int FisrtSeenIdx,int Count);
}

class Q387_FirstUniqueCharacterTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["leetcode", 0],
        ["loveleetcode", 2],
        ["aabb", -1],
        ["aadadaad", -1],
        ["dddccdbba", 8],
    ];
}

public class Q387_FirstUniqueCharacterTests
{
    [Theory]
    [ClassData(typeof(Q387_FirstUniqueCharacterTestData))]
    public void OfficialTestCases(string s, int expected)
    {
        var q = new Q387_FirstUniqueCharacter();
        int result = q.FirstUniqChar(s);
        Assert.Equal(expected, result);
    }
}
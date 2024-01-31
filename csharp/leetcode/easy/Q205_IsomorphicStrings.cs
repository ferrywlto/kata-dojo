namespace dojo.leetcode;

public class Q205_IsomorphicStrings
{
    public bool IsIsomorphic(string s, string t)
    {
        // 1. Two strings must in same length
        if (s.Length != t.Length) return false;

        // 2. If one char map to multiple chars, it must be false
        // 3. There should be no two keys map to the same character 
        var dict = new Dictionary<char, char>();
        for(var i = 0; i<s.Length; i++) 
        {
            if (!dict.TryGetValue(s[i], out char value))
            {
                // Key exist but mapped to a value already exist
                if (dict.ContainsValue(t[i]))
                {
                    return false;
                }
                // Key not exist and not duplicates
                dict.Add(s[i], t[i]);
            }
            // Same key mapped to multiple characters
            else if (value != t[i])
            {
                return false;
            }
        }
        return true;
    }
}

public class Q205_IsomorphicStringsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["egg", "add", true],
        ["foo", "bar", false],
        ["paper", "title", true],
        ["bbbaaaba", "aaabbbba", false],
        ["badc", "baba", false],
    ];
}

public class Q205_IsomorphicStringsTest
{
    [Theory]
    [ClassData(typeof(Q205_IsomorphicStringsTestData))]
    public void OfficialTestCases(string input1, string input2, bool expected)
    {
        var sut = new Q205_IsomorphicStrings();
        var actual = sut.IsIsomorphic(input1, input2);

        Assert.Equal(expected, actual);
    }
}
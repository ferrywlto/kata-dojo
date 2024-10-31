public class Q2287_RearrangeCharactersToMakeTargetString
{
    // TC: O(n+m), n scale with length of s, plus n length of target, plus m unique characters in target
    // SC: O(m), m scale with unique characters in target, another m for sDict
    public int RearrangeCharacters(string s, string target)
    {
        var targetDict = target.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        var sDict = new Dictionary<char, int>();
        foreach(var c in s)
        {
            if (targetDict.ContainsKey(c))
            {
                if (sDict.TryGetValue(c, out var val)) sDict[c] = ++val;
                else sDict.Add(c, 1);
            }
        }

        var result = int.MaxValue;
        foreach (var p in targetDict)
        {
            if (!sDict.TryGetValue(p.Key, out var value)) return 0;
            var temp = value / p.Value;
            if (temp < result) result = temp;
        }

        return result;
    }
    public static List<object[]> TestData =>
    [
        ["ilovecodingonleetcode", "code", 2],
        ["abcba", "abc", 1],
        ["abbaccaddaeea", "aaaaa", 1],
        ["abc", "abcd", 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string target, int expected)
    {
        var actual = RearrangeCharacters(input, target);
        Assert.Equal(expected, actual);
    }
}
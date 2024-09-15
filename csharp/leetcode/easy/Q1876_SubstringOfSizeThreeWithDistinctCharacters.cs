class Q1876_SubstringOfSizeThreeWithDistinctCharacters
{
    // TC: O(n), where n scale with length of s
    // SC: O(1), space used does not scale with input
    public int CountGoodSubstrings(string s)
    {
        var goodCount = 0;
        for (var i = 0; i < s.Length - 2; i++)
        {
            var substring = s[i..(i + 3)];
            var distrubtion = new char[26];
            var good = true;
            for (var j = 0; j < substring.Length; j++)
            {
                var idx = substring[j] - 'a';
                if (distrubtion[idx] == 1)
                {
                    good = false;
                    break;
                }
                distrubtion[idx]++;
            }
            if (good) goodCount++;
        }
        return goodCount;
    }
}
class Q1876_SubstringOfSizeThreeWithDistinctCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["xyzzaz", 1],
        ["aababcabc", 4],
    ];
}
public class Q1876_SubstringOfSizeThreeWithDistinctCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1876_SubstringOfSizeThreeWithDistinctCharactersTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1876_SubstringOfSizeThreeWithDistinctCharacters();
        var actual = sut.CountGoodSubstrings(input);
        Assert.Equal(expected, actual);
    }
}
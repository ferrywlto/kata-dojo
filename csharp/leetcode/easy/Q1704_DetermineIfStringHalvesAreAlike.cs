class Q1704_DetermineIfStringHalvesAreAlike
{
    // TC: O(n), where n is length of s, it have to iterate all characters
    // SC: O(1), space used is fixed
    public bool HalvesAreAlike(string s)
    {
        var set = new HashSet<char>
        {
            {'a'},{'A'},
            {'e'},{'E'},
            {'i'},{'I'},
            {'o'},{'O'},
            {'u'},{'U'},
        };
        var count = 0;
        for(var i=0; i<s.Length/2; i++)
        {
            if(set.Contains(s[i])) count++;
        }
        for(var j=s.Length/2; j<s.Length; j++)
        {
            if (set.Contains(s[j])) count--;
        }
        return count == 0;
    }
}
class Q1704_DetermineIfStringHalvesAreAlikeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["book", true],
        ["textbook", false],
        ["AbCdEfGh", true],
    ];
}
public class Q1704_DetermineIfStringHalvesAreAlikeTests
{
    [Theory]
    [ClassData(typeof(Q1704_DetermineIfStringHalvesAreAlikeTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1704_DetermineIfStringHalvesAreAlike();
        var actual = sut.HalvesAreAlike(input);
        Assert.Equal(expected, actual);
    }
}
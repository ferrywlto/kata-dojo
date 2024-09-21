class Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurances
{
    // TC: O(n), where n is length of s
    // SC: O(1), space used does not scale with s
    public bool AreOccurrencesEqual(string s)
    {
        int[] count = new int[26];
        for (var i = 0; i < s.Length; i++) count[s[i] - 'a']++;

        var temp = -1;
        foreach (var c in count)
        {
            if (c == 0) continue;
            if (c > 0 && temp == -1) temp = c;
            else if (c != temp) return false;
        }
        return true;
    }
}
class Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurancesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["abacbc", true],
        ["aaabb", false],
    ];
}
public class Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurancesTests
{
    [Theory]
    [ClassData(typeof(Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurancesTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurances();
        var actual = sut.AreOccurrencesEqual(input);
        Assert.Equal(expected, actual);
    }
}
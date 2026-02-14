class Q1684_CountTheNumberOfConsistentString
{
    // TC: O(n), it have to walkthough all character in words worst case if all characters are allowed
    // TC: O(m), m is length of allowed
    public int CountConsistentStrings(string allowed, string[] words)
    {
        var result = 0;
        var allowSet = allowed.ToHashSet();
        for (var i = 0; i < words.Length; i++)
        {
            var valid = true;
            for (var j = 0; j < words[i].Length; j++)
            {
                if (!allowSet.Contains(words[i][j]))
                {
                    valid = false;
                    break;
                }
            }
            if (valid) result++;
        }
        return result;
    }
}
class Q1684_CountTheNumberOfConsistentStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["ab", new string[] {"ad","bd","aaab","baa","badab"}, 2],
        ["abc", new string[] {"a","b","c","ab","ac","bc","abc"}, 7],
        ["cad", new string[] {"cc","acd","b","ba","bac","bad","ac","d"}, 4],
    ];
}
public class Q1684_CountTheNumberOfConsistentStringTests
{
    [Theory]
    [ClassData(typeof(Q1684_CountTheNumberOfConsistentStringTestData))]
    public void OfficialTestCases(string allowed, string[] words, int expected)
    {
        var sut = new Q1684_CountTheNumberOfConsistentString();
        var actual = sut.CountConsistentStrings(allowed, words);
        Assert.Equal(expected, actual);
    }
}

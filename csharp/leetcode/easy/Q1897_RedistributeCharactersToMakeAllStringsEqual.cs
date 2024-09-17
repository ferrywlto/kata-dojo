class Q1897_RedistributeCharactersTomakeAllStringsEqual
{
    // TC: O(n + m), where n is total characters in words, m is constant to 26
    // SC: O(1), space used in dictionary is constant
    public bool MakeEqual(string[] words)
    {
        var dict = new Dictionary<char, int>() {
            {'a',0},
            {'b',0},
            {'c',0},
            {'d',0},
            {'e',0},
            {'f',0},
            {'g',0},
            {'h',0},
            {'i',0},
            {'j',0},
            {'k',0},
            {'l',0},
            {'m',0},
            {'n',0},
            {'o',0},
            {'p',0},
            {'q',0},
            {'r',0},
            {'s',0},
            {'t',0},
            {'u',0},
            {'v',0},
            {'w',0},
            {'x',0},
            {'y',0},
            {'z',0},
        };
        foreach (var w in words) foreach (var c in w) dict[c]++;
        return dict.All(x => x.Value % words.Length == 0);
    }
}
class Q1897_RedistributeCharactersTomakeAllStringsEqualTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"abc","aabc","bc"}, true],
        [new string[] {"ab", "a"}, false],
    ];
}
public class Q1897_RedistributeCharactersTomakeAllStringsEqualTests
{
    [Theory]
    [ClassData(typeof(Q1897_RedistributeCharactersTomakeAllStringsEqualTestData))]
    public void OfficialTestCases(string[] input, bool expected)
    {
        var sut = new Q1897_RedistributeCharactersTomakeAllStringsEqual();
        var actual = sut.MakeEqual(input);
        Assert.Equal(expected, actual);
    }
}
class Q1160_FindWordsThatCanBeFormedByCharacters
{
    public int CountCharacters(string[] words, string chars)
    {
        return 0;
    }
}
class Q1160_FindWordsThatCanBeFormedByCharactersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new string[] {"cat","bt","hat","tree"}, "atach", 6],
        [new string[] {"hello","world","leetcode"}, "welldonehoneyr", 10],
    ];
}
public class Q1160_FindWordsThatCanBeFormedByCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1160_FindWordsThatCanBeFormedByCharactersTestData))]
    public void OfficialTestCases(string[] input, string chars, int expected)
    {
        var sut = new Q1160_FindWordsThatCanBeFormedByCharacters();
        var actual = sut.CountCharacters(input, chars);
        Assert.Equal(expected, actual);
    }
}
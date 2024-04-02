
namespace dojo.leetcode;

public class Q804_UniqueMoreseCodeWords
{
    public int UniqueMorseRepresentations(string[] words) 
    {
        return 0;    
    }    
}

public class Q804_UniqueMoreseCodeWordsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new string[] {"gin","zen","gig","msg"}, 2],
        [new string[] {"a"}, 1],
    ];
}

public class Q804_UniqueMoreseCodeWordsTests
{
    [Theory]
    [ClassData(typeof(Q804_UniqueMoreseCodeWordsTestData))]
    public void OfficialTestCases(string[] input, int expected)
    {
        var sut = new Q804_UniqueMoreseCodeWords();
        var actual = sut.UniqueMorseRepresentations(input);
        Assert.Equal(expected, actual);
    }
}
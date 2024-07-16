class Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentence
{
    // TC: O(n+m), where n is the length of sentence for .Split() and m is the number of words splited to loop through. 
    // SC: O(n), where n is the words splited from sentence
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        var words = sentence.Split(' ');
        for(var i=0; i<words.Length; i++)
        {
            if (words[i].StartsWith(searchWord)) return i + 1;
        }
        return -1;
    }
}
class Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentenceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["i love eating burger", "burg", 4],
        ["this problem is an easy problem", "pro", 2],
        ["i am tired", "you", -1],
    ];
}
public class Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentenceTests
{
    [Theory]
    [ClassData(typeof(Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentenceTestData))]
    public void OfficialTestCases(string input, string target, int expected)
    {
        var sut = new Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentence();
        var actual = sut.IsPrefixOfWord(input, target);
        Assert.Equal(expected, actual);
    }
}
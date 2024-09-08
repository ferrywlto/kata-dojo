class Q1816_TruncateSentence
{
    // TC: O(n), where n is the length of s
    // SC: O(1), space used is fixed
    public string TruncateSentence(string s, int k)
    {
        var endIdx = 0;
        var wordCount = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                wordCount++;
                endIdx = i;
            }
            if (wordCount == k)
            {
                return s[..endIdx];
            }
        }
        return s;
    }
}
class Q1816_TruncateSentenceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["Hello how are you Contestant", 3, "Hello how are"],
        ["Hello how are you Contestant", 4, "Hello how are you"],
        ["What is the solution to this problem", 4, "What is the solution"],
        ["chopper is not a tanuki", 5, "chopper is not a tanuki"],
    ];
}
public class Q1816_TruncateSentenceTests
{
    [Theory]
    [ClassData(typeof(Q1816_TruncateSentenceTestData))]
    public void OfficialTestCases(string input, int k, string expected)
    {
        var sut = new Q1816_TruncateSentence();
        var actual = sut.TruncateSentence(input, k);
        Assert.Equal(expected, actual);
    }
}
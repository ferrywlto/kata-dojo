using System.Text;

// TC: O(n^2), where n is length of sequece and n again for each word appended
// SC: O(n), where n is the length of sequence worst case if sequence == word
class Q1668_MaxRepeatingSubstring
{
    public int MaxRepeating(string sequence, string word) 
    {
        var sb = new StringBuilder(word);
        var result = 0;
        while(sb.Length <= sequence.Length)
        {
            if (sequence.Contains(sb.ToString())) result++;
            sb.Append(word);
        }
        return result;    
    }    
}
class Q1668_MaxRepeatingSubstringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["ababc", "ab", 2],
        ["ababc", "ba", 1],
        ["ababc", "ac", 0],

    ];
}
public class Q1668_MaxRepeatingSubstringTests
{
    [Theory]
    [ClassData(typeof(Q1668_MaxRepeatingSubstringTestData))]
    public void OfficialTestCases(string input, string word, int expected)
    {
        var sut = new Q1668_MaxRepeatingSubstring();
        var actual = sut.MaxRepeating(input, word);
        Assert.Equal(expected, actual);
    }
}
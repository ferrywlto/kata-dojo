class Q1446_ConsecutiveCharacters
{
    // TC: O(n), it have to iterate to the end to determine the longest
    // SC: O(1), no space used in operations
    public int MaxPower(string s)
    {
        var maxLength = 1;
        var currentLength = 1;
        var lastChar = s[0];
        for(var i=1; i<s.Length; i++)
        {
            if(s[i] == lastChar) currentLength++;
            else
            {
                if (currentLength > maxLength) 
                    maxLength = currentLength;
                lastChar = s[i];
                currentLength = 1;
            }
        }
        if (currentLength > maxLength) 
            maxLength = currentLength;
        return maxLength;
    }
}
class Q1446_ConsecutiveCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["leetcode", 2],
        ["abbcccddddeeeeedcba", 5],
    ];
}
public class Q1446_ConsecutiveCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1446_ConsecutiveCharactersTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1446_ConsecutiveCharacters();
        var actual = sut.MaxPower(input);
        Assert.Equal(expected, actual);
    }
}
class Q1805_NumDiffIntegersInString
{
    // TC: O(n), where n is lenght of word
    // SC: O(m), where m is unique number exists in word
    public int NumDifferentIntegers(string word)
    {
        var set = new HashSet<string>();
        var startIdx = -1;
        var inSequence = false;
        for (var i = 0; i < word.Length; i++)
        {
            if (word[i] <= '9' && !inSequence)
            {
                startIdx = i;
                inSequence = true;
            }
            else if (word[i] > '9' && inSequence)
            {
                set.Add(word[startIdx..i].TrimStart('0'));
                inSequence = false;
            }
        }
        if (inSequence)
        {
            set.Add(word[startIdx..].TrimStart('0'));
        }
        return set.Count;
    }
    public string removeLeadingZeros(string input)
    {
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] > '0') return input[i..];
        }
        return "0";
    }
}
class Q1805_NumDiffIntegersInStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["a123bc34d8ef34", 3],
        ["leet1234code234", 2],
        ["a1b01c001", 1],
        ["abc", 0],
        ["abc1", 1],
        ["abc"+int.MaxValue, 1],
    ];
}
public class Q1805_NumDiffIntegersInStringTests
{
    [Theory]
    [ClassData(typeof(Q1805_NumDiffIntegersInStringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1805_NumDiffIntegersInString();
        var actual = sut.NumDifferentIntegers(input);
        Assert.Equal(expected, actual);
    }
}

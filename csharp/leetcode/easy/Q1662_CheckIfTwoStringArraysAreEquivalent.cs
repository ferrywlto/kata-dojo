using System.Text;

class WordsHelper 
{
    private readonly string[] _words;
    public readonly int TotalLength;
    public WordsHelper(string[] words)
    {
        _words = words;
        TotalLength = _words.Sum(w => w.Length);
    }
    public int position = 0;
    public int wordIdx = 0;
    public int charIdx = 0;

    public char NextChar()
    {
        if (position >= TotalLength) return '\0';

        position++;
        if(charIdx == _words[wordIdx].Length)
        {
            charIdx = 0;
            wordIdx++;
        }
        return _words[wordIdx][charIdx++];
    }
}

class Q1662_CheckIfTwoStringArraysAreEquivalent
{
    // TC: O(n), where n is min length of total characters between word1 and word2
    // SC: O(1), the variables used in WordsHelper are fixed
    public bool ArrayStringsAreEqual_O1Space(string[] word1, string[] word2)
    {
        var helper1 = new WordsHelper(word1);
        var helper2 = new WordsHelper(word2);
        if (helper1.TotalLength != helper2.TotalLength) return false;

        var idx = 0;
        while(idx < helper1.TotalLength)
        {
            if (helper1.NextChar() != helper2.NextChar()) return false;
            idx++;
        }
        return true;
    }

    // TC: O(n), where n is min length of total characters between word1 and word2
    // SC: O(n), two string builder are used, worst case is both word1 and word2 are equivalent to hold the complete two strings
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();
        var idx1 = 0;
        var idx2 = 0;
        var compareIdx = 0;
        while(idx1 < word1.Length || idx2 < word2.Length)
        {
            if(idx1 < word1.Length)
            {
                sb1.Append(word1[idx1++]);
            }
            if(idx2 < word2.Length)
            {
                sb2.Append(word2[idx2++]);
            }
            var end = Math.Min(sb1.Length, sb2.Length) - 1;
            for(var i = compareIdx; i<=end; i++)
            {
                if (sb1[i] != sb2[i]) return false;
            }
            compareIdx = end + 1;
        }

        return sb1.Length == sb2.Length;
    }
}
class Q1662_CheckIfTwoStringArraysAreEquivalentTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"ab", "c"}, new string[] {"a", "bc"}, true],
        [new string[] {"a", "cb"}, new string[] {"ab", "c"}, false],
        [new string[] {"abc", "d", "defg"}, new string[] {"abcddefg"}, true],
        [new string[] {"abc","d","defg"}, new string[] {"abcddef"}, false],
        [new string[] {"hoei","uievbxjybmfprhzokvygijitrcmfrlbhlfotuosxyyhrxfllccp","nvwyqf","s"}, new string[] {"hoeiuievbxjybmf","pr","hzokvygij","itrcmfrlbhlfotuosxyyhrx","fllccpnvwyqf","z"}, false],
    ];
}
public class Q1662_CheckIfTwoStringArraysAreEquivalentTests
{
    [Theory]
    [ClassData(typeof(Q1662_CheckIfTwoStringArraysAreEquivalentTestData))]
    public void OfficialTestCases(string[] input1, string[] input2, bool expected)
    {
        var sut = new Q1662_CheckIfTwoStringArraysAreEquivalent();
        var actual = sut.ArrayStringsAreEqual(input1, input2);
        Assert.Equal(expected, actual);
    }
}
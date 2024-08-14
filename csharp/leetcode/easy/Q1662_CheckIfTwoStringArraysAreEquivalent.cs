using System.Text;

class Q1662_CheckIfTwoStringArraysAreEquivalent
{
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
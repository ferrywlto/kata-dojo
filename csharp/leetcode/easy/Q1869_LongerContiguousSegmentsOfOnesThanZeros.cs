class Q1869_LongerContiguousSegmentsOfOnesThanZeros
{
    // TC: O(n), where n is length of s
    // SC: O(1), space used does not scale with input
    public bool CheckZeroOnes(string s)
    {
        var lengthZeros = 0;
        var lengthOnes = 0;
        var maxLengthZeros = int.MinValue;
        var maxLengthOnes = int.MinValue;
        for(var i = 0; i<s.Length; i++)
        {
            if(s[i] == '0')
            {
                lengthOnes = 0;
                lengthZeros++;
                if (lengthZeros > maxLengthZeros) maxLengthZeros = lengthZeros;
            }
            else 
            {
                lengthZeros = 0;
                lengthOnes++;
                if (lengthOnes > maxLengthOnes) maxLengthOnes = lengthOnes;

            }
        }
        return maxLengthOnes > maxLengthZeros;
    }
}
class Q1869_LongerContiguousSegmentsOfOnesThanZerosTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["1101", true],
        ["111000", false],
        ["110100010", false],
        ["01111110", true],
        ["0", false],
        ["000", false],
        ["1", true],
        ["111", true],
    ];
}
public class Q1869_LongerContiguousSegmentsOfOnesThanZerosTests
{
    [Theory]
    [ClassData(typeof(Q1869_LongerContiguousSegmentsOfOnesThanZerosTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1869_LongerContiguousSegmentsOfOnesThanZeros();
        var actual = sut.CheckZeroOnes(input);
        Assert.Equal(expected, actual);
    }
}
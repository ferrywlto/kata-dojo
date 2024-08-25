class Q1720_DecodeXorArray
{
    // TC: O(n), where n is the length of encoded
    // SC: O(n), where n is length of encoded + 1, if not counting the space to hold the result, its O(1)
    public int[] Decode(int[] encoded, int first)
    {
        var result = new int[encoded.Length + 1];
        result[0] = first;
        for(var i=1; i<result.Length; i++)
        {
            result[i] = result[i - 1] ^ encoded[i - 1];
        }
        return result;
    }
}
class Q1720_DecodeXorArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,2,3}, 1, new int[] {1,0,2,1}],
        [new int[] {6,2,7,3}, 4, new int[] {4,2,0,7,4}],
    ];
}
public class Q1720_DecodeXorArrayTests
{
    [Theory]
    [ClassData(typeof(Q1720_DecodeXorArrayTestData))]
    public void OfficialTestCases(int[] input, int first, int[] expected)
    {
        var sut = new Q1720_DecodeXorArray();
        var actual = sut.Decode(input, first);
        Assert.Equal(expected, actual);
    }
}

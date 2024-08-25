class Q1720_DecodeXorArray
{
    public int[] Decode(int[] encoded, int first)
    {
        return [];
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

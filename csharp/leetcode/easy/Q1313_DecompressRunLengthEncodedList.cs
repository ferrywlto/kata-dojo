
class Q1313_DecompressRunLengthEncodedList
{
    public int[] DecompressRLElist(int[] nums) 
    {
        return [];    
    }
}
class Q1313_DecompressRunLengthEncodedListTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,2,3,4}, new int[] {2,4,4,4}],
        [new int[] {1,1,2,3}, new int[] {1,3,3}],
    ];
}
public class Q1313_DecompressRunLengthEncodedListTests
{
    [Theory]
    [ClassData(typeof(Q1313_DecompressRunLengthEncodedListTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1313_DecompressRunLengthEncodedList();
        var actual = sut.DecompressRLElist(input);
        Assert.Equal(expected, actual);
    }
}
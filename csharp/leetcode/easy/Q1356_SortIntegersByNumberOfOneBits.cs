class Q1356_SortIntegersByNumberOfOneBits
{
    public int[] SortByBits(int[] arr)
    {
        return [];
    }
}
class Q1356_SortIntegersByNumberOfOneBitsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{0,1,2,3,4,5,6,7,8}, new int[]{0,1,2,4,8,3,5,6,7}],
        [new int[]{1024,512,256,128,64,32,16,8,4,2,1}, new int[]{1,2,4,8,16,32,64,128,256,512,1024}],
    ];
}
public class Q1356_SortIntegersByNumberOfOneBitsTests
{
    [Theory]
    [ClassData(typeof(Q1356_SortIntegersByNumberOfOneBitsTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1356_SortIntegersByNumberOfOneBits();
        var actual = sut.SortByBits(input);
        Assert.Equal(expected, actual);
    }
}
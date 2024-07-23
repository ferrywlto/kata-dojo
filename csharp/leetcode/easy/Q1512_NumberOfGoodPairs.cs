
class Q1512_NumberOfGoodPairs
{
    public int NumIdenticalPairs(int[] nums) 
    {
        return 0;    
    }
}
class Q1512_NumberOfGoodPairsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,2,3,1,1,3}, 4],
        [new int[] {1,1,1,1}, 6],
        [new int[] {1,2,3}, 0],
    ];
}
public class Q1512_NumberOfGoodPairsTests
{
    [Theory]
    [ClassData(typeof(Q1512_NumberOfGoodPairsTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1512_NumberOfGoodPairs();
        var actual = sut.NumIdenticalPairs(input);
        Assert.Equal(expected, actual);
    }
}
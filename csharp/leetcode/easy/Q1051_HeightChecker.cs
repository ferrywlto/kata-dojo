
class Q1051_HeightCHecker
{
    public int HeightChecker(int[] heights) 
    {
        return 0;    
    }    
}
class Q1051_HeightCHeckerTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,1,4,2,1,3}, 3],
        [new int[]{5,1,2,3,4}, 5],
        [new int[]{1,2,3,4,5}, 0],
    ];
}
public class Q1051_HeightCHeckerTests
{
    [Theory]
    [ClassData(typeof(Q1051_HeightCHeckerTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1051_HeightCHecker();
        var actual = sut.HeightChecker(input);
        Assert.Equal(expected, actual);
    }
}
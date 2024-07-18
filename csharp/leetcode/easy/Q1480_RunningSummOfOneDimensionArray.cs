
class Q1480_RunningSumOfOneDimensionArray
{
    public int[] RunningSum(int[] nums) 
    {
        return [];    
    }
}
class Q1480_RunningSumOfOneDimensionArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,2,3,4}, new int[] {1,3,6,10}],
        [new int[] {1,1,1,1,1}, new int[] {1,2,3,4,5}],
        [new int[] {3,1,2,10,1}, new int[] {3,4,6,16,17}],
    ];
}
public class Q1480_RunningSumOfOneDimensionArrayTests
{
    [Theory]
    [ClassData(typeof(Q1480_RunningSumOfOneDimensionArrayTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1480_RunningSumOfOneDimensionArray();
        var actual = sut.RunningSum(input);
        Assert.Equal(expected, actual);
    }
}

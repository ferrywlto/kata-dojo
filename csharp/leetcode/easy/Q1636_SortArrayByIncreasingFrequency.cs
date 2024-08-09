
class Q1636_SortArrayByIncreasingFrequency
{
    public int[] FrequencySort(int[] nums) 
    {
        return [];    
    }    
}
class Q1636_SortArrayByIncreasingFrequencyTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,1,2,2,2,3}, new int[] {3,1,1,2,2,2}],
        [new int[] {2,3,1,3,2}, new int[] {1,3,3,2,2}],
        [new int[] {-1,1,-6,4,5,-6,1,4,1}, new int[] {5,-1,4,4,-6,-6,1,1,1}],
    ];
}
public class Q1636_SortArrayByIncreasingFrequencyTests
{
    [Theory]
    [ClassData(typeof(Q1636_SortArrayByIncreasingFrequencyTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1636_SortArrayByIncreasingFrequency();
        var actual = sut.FrequencySort(input);
        Assert.Equal(expected, actual);
    }
}
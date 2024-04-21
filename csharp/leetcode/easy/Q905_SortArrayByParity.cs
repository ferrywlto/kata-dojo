
class Q905_SortArrayByParity
{
    public int[] SortArrayByParity(int[] nums) 
    {
        return [];    
    }
}

class Q905_SortArrayByParityTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{3,1,2,4}, new int[]{2,4,3,1}],
        [new int[]{0}, new int[]{0}],
    ];
}

public class Q905_SortArrayByParityTests
{
    [Theory]
    [ClassData(typeof(Q905_SortArrayByParityTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q905_SortArrayByParity();
        var actual = sut.SortArrayByParity(input);
        Assert.Equal(expected, actual);
    }
}
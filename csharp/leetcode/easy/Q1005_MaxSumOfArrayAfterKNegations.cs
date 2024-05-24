
class Q1005_MaxSumOfArrayAfterNegations
{
    public int LargestSumAfterKNegations(int[] nums, int k) 
    {
        return 0;    
    }
}

class Q1005_MaxSumOfArrayAfterNegationsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{4,2,3}, 1, 5],
        [new int[]{3,-1,0,2}, 3, 6],
        [new int[]{2,-3,-1,5,-4}, 2, 13],
    ];
}

public class Q1005_MaxSumOfArrayAfterNegationsTests
{
    [Theory]
    [ClassData(typeof(Q1005_MaxSumOfArrayAfterNegationsTestData))]
    public void OfficialTestCases(int[] input, int k, int expected)
    {
        var sut = new Q1005_MaxSumOfArrayAfterNegations();
        var actual = sut.LargestSumAfterKNegations(input, k);
        Assert.Equal(expected, actual);
    }
}
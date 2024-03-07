namespace dojo.leetcode;

public class Q643_MaxAvgSubarrayI
{
    public double FindMaxAverage(int[] nums, int k) 
    {
        return 0;    
    }
}

public class Q643_MaxAvgSubarrayITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,12,-5,-6,50,3}, 4, 12.75000],
        [new int[]{5}, 1, 5.00000],
    ];
}

public class Q643_MaxAvgSubarrayITests
{
    [Theory]
    [ClassData(typeof(Q643_MaxAvgSubarrayITestData))]
    public void OfficialTestCases(int[] input, int k, double expected)
    {
        var sut = new Q643_MaxAvgSubarrayI();
        var actual = sut.FindMaxAverage(input, k);
        Assert.Equal(expected, actual);
    }
}
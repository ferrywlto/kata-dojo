namespace dojo.leetcode;

public class Q643_MaxAvgSubarrayI
{
    // TC: O(n^2)
    // SC: O(1)
    public double FindMaxAverage(int[] nums, int k) 
    {
        if (nums.Length <= k) return nums.Average();

        var maxAvg = double.MinValue;

        for(var i=0; i<nums.Length-(k-1); i++)
        {
            var sum = 0;
            for(var j=i; j<i+k; j++)
            {
                sum += nums[j];
                Console.WriteLine($"n: {nums[j]}, currentSum: {sum}");
            }
            var avg = (double)sum / k;
            if (avg > maxAvg)
            {
                maxAvg = avg;
            }
            Console.WriteLine($"range: {i}-{i + k - 1}, sum: {sum}, avg: {avg}");
        }
        
        return maxAvg;
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
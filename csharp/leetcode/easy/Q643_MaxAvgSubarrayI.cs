class Q643_MaxAvgSubarrayI
{
    // TC: O(n^2)
    // SC: O(1)
    public double FindMaxAverage(int[] nums, int k)
    {
        double known = 0;
        for (var i = 0; i < k; i++) known += nums[i];

        var maxAvg = known / k;
        for (var j = 1; j < nums.Length - (k - 1); j++)
        {
            var prevHead = nums[j - 1];
            var nextTail = nums[j + k - 1];
            known = known - prevHead + nextTail;

            var movingAvg = known / k;
            if (movingAvg > maxAvg) maxAvg = movingAvg;
        }

        return maxAvg;
    }
}

class Q643_MaxAvgSubarrayITestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,12,-5,-6,50,3}, 4, 12.75000],
        [new int[]{4,2,1,3,3}, 2, 3.00000],
        [new int[]{7,4,5,8,8,3,9,8,7,6}, 7, 7.00000],
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

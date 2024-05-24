class Q1005_MaxSumOfArrayAfterNegations
{
    // TC: O(n+2n log n), n is length of nums
    // SC: O(1), the operations are done in-place
    public int LargestSumAfterKNegations(int[] nums, int k) 
    {
        Array.Sort(nums);
        var replaced = 0;
        var idx = 0;
        var min = int.MaxValue;
        while(idx < nums.Length && replaced < k)
        {
            if(nums[idx] < 0) 
            {
                nums[idx] = -nums[idx];
                replaced++;
            }
            if(nums[idx] < min)
            {
                min = nums[idx];
            }
            idx++;
        }
        // Since the same number can negate multiple times, up to this point all negative numbers become positive or all negate quota used.
        // If there are still negate quota and it is even, do nothing to maintain the maximium sum.
        var remaining = k - replaced;
        if (remaining %2==0) {
            return nums.Sum(); 
        }

        // If quota is odd, since it can apply multiple times to a number, 
        // negate a positive odd times will always negative, thus only to negate the smallest one

        // The remaining numbers are all positive, minus the min neturalize it, 
        // minus the min again make it equalvalent to make the num negative
        // that's why we have 2*min here
        return nums.Sum() - (2*min);
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
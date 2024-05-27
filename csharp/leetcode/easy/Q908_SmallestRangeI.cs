
class Q908_SmallestRangeI
{
    // TC: O(2n) -> O(n), n is length of nums
    // SC: O(1), no space used
    public int SmallestRangeI(int[] nums, int k)
    {
        if (nums.Length <= 1) return 0;
        
        var avg = nums.Average();
        var max = int.MinValue;
        var min = int.MaxValue;
        for(var i=0; i<nums.Length; i++)
        {
            if(nums[i] > avg) 
            {
                max = Math.Max(max, nums[i] - k);
            }
            else if(nums[i] < avg)
            {
                min = Math.Min(min, nums[i] + k);
            }
        }

        if (max < min) return 0;
        return max - min;
    }

    // TC: O(n) version
    // doesn't need to calculate the average
    // the smallest range can get by max - min (original range) - 2k (down k from max and up k from min)
    // thus doesn't need average
    public int SmallestRangeI_SinglePass(int[] nums, int k)
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < nums.Length; i++)
        {
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }

        return Math.Max(0, max - min - 2 * k);
    }
}

class Q908_SmallestRangeITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{0}, 0, 0],
        [new int[]{1,1,1}, 0, 0],
        [new int[]{1,1,1}, 3, 0],
        [new int[]{0,10}, 2, 6],
        [new int[]{1,3,6}, 3, 0],
        [new int[]{3,1,10}, 4, 1],
        [new int[]{9,9,2,8,7}, 4, 0],
    ];
}

public class Q908_SmallestRangeITests
{
    [Theory]
    [ClassData(typeof(Q908_SmallestRangeITestData))]
    public void OfficialTestCases(int[] input, int k, int expected)
    {
        var sut = new Q908_SmallestRangeI();
        var actual = sut.SmallestRangeI_SinglePass(input, k);
        Assert.Equal(expected, actual);
    }
}
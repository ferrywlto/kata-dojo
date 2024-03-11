namespace dojo.leetcode;

public class Q674_LongestContinuousIncreasingSubSequence
{
    // TC: O(n)
    // SC: O(1)
    public int FindLengthOfLCIS(int[] nums) 
    {
        var maxLength = 1;
        var currentLength = 1;
        for(var i=0; i<nums.Length-1; i++)
        {
            if(nums[i] < nums[i+1])
            {
                currentLength++;
                maxLength = Math.Max(maxLength, currentLength);
            }
            else currentLength = 1;
        }
        return maxLength;    
    }
}

public class Q674_LongestContinuousIncreasingSubSequenceTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,3,5,4,7}, 3],
        [new int[] {2,2,2,2,2}, 1],
    ];
}

public class Q674_LongestContinuousIncreasingSubSequenceTestc
{
    [Theory]
    [ClassData(typeof(Q674_LongestContinuousIncreasingSubSequenceTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q674_LongestContinuousIncreasingSubSequence();
        var actual = sut.FindLengthOfLCIS(input);
        Assert.Equal(expected, actual);
    }
}
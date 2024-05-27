class Q747_LargestNumberAtLeastTwiceOfOthers
{
    // TC: O(n)
    // SC: O(1)
    public int DominantIndex(int[] nums)
    {
        var largest = int.MinValue;
        var secondLargest = largest;
        var idx = -1;
        for(var i=0; i<nums.Length; i++)
        {
            if (nums[i] > largest)
            {
                secondLargest = largest;
                largest = nums[i];
                idx = i;
            }
            else if(nums[i] > secondLargest)
            {
                secondLargest = nums[i];
            }
        }
        return largest >= secondLargest * 2 ? idx : -1;
    }
}

class Q747_LargestNumberAtLeastTwiceOfOthersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        // [new int[]{3,6,1,0}, 1],
        // [new int[]{1,2,3,4}, -1],
        [new int[]{0,0,3,2}, -1],
    ];
}

public class Q747_LargestNumberAtLeastTwiceOfOthersTests
{
    [Theory]
    [ClassData(typeof(Q747_LargestNumberAtLeastTwiceOfOthersTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q747_LargestNumberAtLeastTwiceOfOthers();
        var actual = sut.DominantIndex(input);
        Assert.Equal(expected, actual);
    }
}

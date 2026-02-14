class Q1909_RemoveOneElementToMakeArrayIncreasing
{
    // TC: O(n), where n is length of nums
    // SC: O(1), space used does not scale with input
    public bool CanBeIncreasing(int[] nums)
    {
        if (nums.Length == 2) return true;
        var downIdx = -1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1]) continue;
            else if (downIdx != -1) return false;
            else downIdx = i;
        }

        if (downIdx == -1) return true;
        if (downIdx == 1) return true;
        if (downIdx == nums.Length - 1) return true;
        if (nums[downIdx] > nums[downIdx - 2]) return true; // remove 
        if (nums[downIdx + 1] > nums[downIdx - 1]) return true; // remove self
        return false;
    }
}
class Q1909_RemoveOneElementToMakeArrayIncreasingTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,10,5,7}, true],
        [new int[] {2,3,1,2}, false],
        [new int[] {1,1,1}, false],
        [new int[] {1,1}, true],
        [new int[] {100,21,100}, true],
        [new int[] {1,2,3}, true],
        [new int[] {105,924,32,968}, true],
        [new int[] {512,867,904,997,403}, true],
    ];
}
public class Q1909_RemoveOneElementToMakeArrayIncreasingTests
{
    [Theory]
    [ClassData(typeof(Q1909_RemoveOneElementToMakeArrayIncreasingTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1909_RemoveOneElementToMakeArrayIncreasing();
        var actual = sut.CanBeIncreasing(input);
        Assert.Equal(expected, actual);
    }
}

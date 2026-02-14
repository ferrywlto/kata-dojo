class Q724_FindPivotIndex
{
    // TC: O(n)
    // SC: O(1)
    public int PivotIndex(int[] nums)
    {
        var sum = nums.Sum();
        var leftSum = 0;
        var rightSum = sum;
        for (var i = 0; i < nums.Length; i++)
        {
            rightSum -= nums[i];
            if (leftSum == rightSum) return i;
            leftSum += nums[i];
        }
        return -1;
    }
}

class Q724_FindPivotIndexTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,7,3,6,5,6}, 3],
        [new int[] {1,2,3}, -1],
        [new int[] {2,1,-1}, 0],
    ];
}

public class Q724_FindPivotIndexTests
{
    [Theory]
    [ClassData(typeof(Q724_FindPivotIndexTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q724_FindPivotIndex();
        var actual = sut.PivotIndex(input);
        Assert.Equal(expected, actual);
    }
}

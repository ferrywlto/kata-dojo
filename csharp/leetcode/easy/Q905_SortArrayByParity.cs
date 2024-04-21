class Q905_SortArrayByParity
{
    // TC: O(2n) -> O(n), n is the length of nums
    // SC: O(1), no extra data structure used
    public int[] SortArrayByParity(int[] nums)
    {
        var startSearchIdx = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 1)
            {
                int nextEvenIdx = NextEvenIdx(nums, Math.Max(i, startSearchIdx));
                if (nextEvenIdx == -1) break;

                (nums[nextEvenIdx], nums[i]) = (nums[i], nums[nextEvenIdx]);
                if (nextEvenIdx == nums.Length - 1) break;

                startSearchIdx = nextEvenIdx + 1;
            }
        }
        return nums;
    }

    public int NextEvenIdx(int[] input, int startIdx)
    {
        for (var i = startIdx; i < input.Length; i++)
        {
            if (input[i] % 2 == 0) return i;
        }
        return -1;
    }
}

class Q905_SortArrayByParityTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{3,1,2,4}, new int[]{2,4,3,1}],
        [new int[]{2,1,3,4}, new int[]{2,4,3,1}],
        [new int[]{2,4,3,1}, new int[]{2,4,3,1}],
        [new int[]{0}, new int[]{0}],
    ];
}

public class Q905_SortArrayByParityTests
{
    [Theory]
    [ClassData(typeof(Q905_SortArrayByParityTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q905_SortArrayByParity();
        var actual = sut.SortArrayByParity(input);
        Assert.Equal(expected, actual);
    }

    // [Theory]
    // [InlineData(new int[] { 2 } , 0, 0)]
    // [InlineData(new int[] { 1, 2, 3 } , 0, 1)]
    // [InlineData(new int[] { 1, 2, 3 } , 1, 1)]
    // [InlineData(new int[] { 1, 2, 4, 3 } , 0, 1)]
    // [InlineData(new int[] { 1, 2, 4, 3 } , 1, 1)]
    // public void NextEvenIdx_StartFromFirstEvenOrBefore_ReturnCorrectIndex(int[] input, int startIdx, int expected) 
    // => Assert_NextEvenIdx(input, startIdx, expected);

    // [Theory]
    // [InlineData(new int[] { 1, 2, 4, 3 } , 2, 2)]
    // public void NextEvenIdx_StartFromSecondEven_ReturnCorrectIndex(int[] input, int startIdx, int expected) => Assert_NextEvenIdx(input, startIdx, expected);

    // [Theory]
    // [InlineData(new int[] { 2 } , 1, -1)]
    // [InlineData(new int[] { 1, 2, 3 } , 2, -1)]
    // public void NextEvenIdx_StartAfterLastEven_ReturnNegativeOne(int[] input, int startIdx, int expected) => Assert_NextEvenIdx(input, startIdx, expected);

    // [Theory]
    // [InlineData(new int[] { 1 } , 0, -1)]
    // [InlineData(new int[] { 1 } , 1, -1)]
    // public void NextEvenIdx_InputNoEven_ReturnNegativeOne(int[] input, int startIdx, int expected) => Assert_NextEvenIdx(input, startIdx, expected);

    // private void Assert_NextEvenIdx(int[] input, int startIdx, int expected)
    // {
    //     var sut = new Q905_SortArrayByParity();
    //     var actual = sut.NextEvenIdx(input, startIdx);
    //     Assert.Equal(expected, actual);
    // }
}
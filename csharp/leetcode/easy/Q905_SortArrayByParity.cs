class Q905_SortArrayByParity
{
    // TC: O(n/2) -> O(n), which improves time from original O(2n) 
    public int[] SortArrayByParity_TwoPointers(int[] nums)
    {
        var startIdx = 0;
        var endIdx = nums.Length - 1;
        while (startIdx < endIdx)
        {
            // Means an odd at the beginning and an even at the end, which is the swap case
            if (nums[startIdx] % 2 > nums[endIdx] % 2)
            {
                (nums[startIdx], nums[endIdx]) = (nums[endIdx], nums[startIdx]);
            }

            if(nums[startIdx] % 2 == 0) startIdx++;
            if(nums[endIdx] % 2 == 1) endIdx--;
        }
        return nums;
    }

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
        [new int[]{3,1,2,4}, new int[]{4,2,1,3}],
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
        var actual = sut.SortArrayByParity_TwoPointers(input);
        Assert.Equal(expected, actual);
    }
}
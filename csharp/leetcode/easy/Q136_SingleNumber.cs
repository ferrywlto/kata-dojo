class Q136_SingleNumberTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] { 2, 2, 1 }, 1],
        [new int[] { 4, 1, 2, 1, 2 }, 4],
        [new int[] { 1 }, 1],
        [new int[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 7, 6, 6 }, 7],
        [new int[] { 1, 1, 2, 3, 3 }, 2],
        [new int[] { 1, 2, 2, 3, 3 }, 1],
        [new int[] { 1, 2, 1, 3, 3 }, 2],
    ];
}

public class Q136_SingleNumberTests
{
    [Theory]
    [ClassData(typeof(Q136_SingleNumberTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q136_SingleNumber();
        var actual = sut.SingleNumber_XOR(input);
        Assert.Equal(expected, actual);
    }
}

/*
Constraints:

1 <= nums.length <= 3 * 104
-3 * 104 <= nums[i] <= 3 * 104
Each element in the array appears twice except for one element which appears only once.
*/
class Q136_SingleNumber
{
    // The length of of input must be odd number in order to have n pairs and 1 single number
    // Complexity requirement: TC: O(n), SC: O(1)
    // But Array.Sort() is TC: O(nlogn)
    public int SingleNumber(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        Array.Sort(nums);
        for (var i = 0; i < nums.Length - 1; i += 2)
        {
            if (nums[i] != nums[i + 1])
            {
                return nums[i];
            }
        }
        return nums[^1];
    }

    // TC: O(n), SC: O(1) approach from Copilot using XOR
    public int SingleNumber_XOR(int[] nums)
    {
        int result = 0;
        foreach (int num in nums)
        {
            result ^= num;
        }
        return result;
    }
}

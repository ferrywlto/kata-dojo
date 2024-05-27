class Q169_MajorityElementTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] { 3, 2, 3 }, 3],
        [new int[] { 2, 2, 1, 1, 1, 2, 2}, 2]
    ];
}

public class Q169_MajorityElementTests
{
    [Theory]
    [ClassData(typeof(Q169_MajorityElementTestData))]
    public void OfficialTestCases(int[] nums, int expected)
    {
        var sut = new Q169_MajorityElement();
        var res = sut.MajorityElementEfficient(nums);

        Assert.Equal(expected, res);
    }
}

class Q169_MajorityElement
{
    // TC: O(n), SC: O(n)
    public int MajorityElement(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        var half = nums.Length / 2;
        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.TryGetValue(nums[i], out int value))
            {
                dict[nums[i]] = ++value;
            }
            else
            {
                dict.Add(nums[i], 1);
            }
            if (dict[nums[i]] > half) return nums[i];
        }
        return 0;
    }

    // Demonstration of using Boyer-Moore Voting Algorithm suggested from Copilot
    // TC: O(n), SC: O(1)
    public int MajorityElementEfficient(int[] nums)
    {
        int count = 0;
        int mostOccur = int.MaxValue;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                mostOccur = num;
            }

            if (num == mostOccur)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        return mostOccur;
    }
}
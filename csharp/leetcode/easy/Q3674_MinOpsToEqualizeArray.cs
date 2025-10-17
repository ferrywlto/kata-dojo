public class Q3674_MinOpsToEqualizeArray
{
    // TC: O(n), n scale with length of nums. Worst case all items are equal, n = nums.length
    // SC: O(1), space used does not scale with input.
    public int MinOperations(int[] nums)
    {
        var start = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != start) return 1;
        }
        return 0;
    }

    public static TheoryData<int[], int> TestData => new() { { [1, 2], 1 }, { [5, 5, 5], 0 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

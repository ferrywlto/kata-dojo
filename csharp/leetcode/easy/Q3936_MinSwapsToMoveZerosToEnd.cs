public class Q3936_MinSwapsToMoveZerosToEnd
{
    // TC: O(n), run at most nums.Length times
    // SC: O(1), space used does not scale with input
    public int MinimumSwaps(int[] nums)
    {
        var result = 0;
        var head = 0;
        var tail = nums.Length - 1;
        while (head < tail)
        {
            if (nums[tail] != 0 && nums[head] == 0)
            {
                result++;
                head++;
                tail--;
            }
            else if (nums[tail] == 0) tail--;
            else if (nums[head] != 0) head++;
        }

        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [0, 1, 0, 3, 12], 2 },
        { [0, 1, 0, 2], 1 },
        { [1, 2, 0], 0 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumSwaps(input);
        Assert.Equal(expected, actual);
    }
}

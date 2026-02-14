public class Q2210_CountHillsAndValleysInArray
{
    // TC: O(n), n scale with length of nums, it has to iterate all elements in nums
    // SC: O(1), space used does not scale with input
    public int CountHillValley(int[] nums)
    {
        var result = 0;
        var curr = nums[0];
        var direction = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > curr)
            {
                if (direction == -1)
                {
                    result++;
                }
                direction = 1;
            }
            else if (nums[i] < curr)
            {
                if (direction == 1)
                {
                    result++;
                }
                direction = -1;
            }

            curr = nums[i];
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {2,4,1,1,6,5}, 3],
        [new int[] {6,6,5,5,4,1}, 0],
        [new int[] {1,2,1}, 1],
        [new int[] {2,1,2}, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountHillValley(input);
        Assert.Equal(expected, actual);
    }
}

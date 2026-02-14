public class Q2553_SeparateDigitsInArray
{
    // TC: O(n), n sacle with length of nums
    // SC: O(m), m scale with total digits among all numbers in nums
    public int[] SeparateDigits(int[] nums)
    {
        var stack = new Stack<int>();
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            while (nums[i] > 0)
            {
                stack.Push(nums[i] % 10);
                nums[i] /= 10;
            }
        }
        var list = new List<int>();
        while (stack.Count > 0) list.Add(stack.Pop());
        return [.. list];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {13,25,83,77}, new int[] {1,3,2,5,8,3,7,7}],
        [new int[] {7,1,3,9}, new int[] {7,1,3,9}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = SeparateDigits(input);
        Assert.Equal(expected, actual);
    }
}

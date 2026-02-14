public class Q3300_MinElementAfterReplacementWithDigitSum
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MinElement(int[] nums)
    {
        var min = int.MaxValue;
        for (var i = 0; i < nums.Length; i++)
        {
            var digitSum = 0;
            while (nums[i] > 0)
            {
                digitSum += nums[i] % 10;
                nums[i] /= 10;
            }
            if (digitSum < min) min = digitSum;
        }

        return min;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[10,12,13,14], 1},
        {[1,2,3,4], 1},
        {[999,19,199], 10},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinElement(input);
        Assert.Equal(expected, actual);
    }
}

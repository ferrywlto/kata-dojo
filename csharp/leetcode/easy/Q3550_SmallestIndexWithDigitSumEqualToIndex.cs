public class Q3550_SmallestIndexWithDigitSumEqualToIndex
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int SmallestIndex(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var temp = nums[i];
            var digitSum = 0;
            while (temp > 0)
            {
                digitSum += temp % 10;
                temp /= 10;
            }
            if (digitSum == i) return i;
        }
        return -1;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,3,2], 2},
        {[1,10,11], 1},
        {[1,2,3], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SmallestIndex(input);
        Assert.Equal(expected, actual);
    }
}

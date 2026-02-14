public class Q3232_FindIfDigitGameCanBeWon
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public bool CanAliceWin(int[] nums)
    {
        var singleSum = 0;
        var doubleSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 9) doubleSum += nums[i];
            else singleSum += nums[i];
        }
        return singleSum != doubleSum;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1,2,3,4,10], false},
        {[1,2,3,4,5,14], true},
        {[5,5,5,25], true},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = CanAliceWin(input);
        Assert.Equal(expected, actual);
    }
}

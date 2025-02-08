public class Q3158_FindXORofNumbersWhichAppearTwice
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int DuplicateNumbersXOR(int[] nums)
    {
        var temp = new int[51];
        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (temp[nums[i]] == 1)
            {
                result ^= nums[i];
            }
            else temp[nums[i]]++;

        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,1,3], 1},
        {[1,2,3], 0},
        {[1,2,2,1], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = DuplicateNumbersXOR(input);
        Assert.Equal(expected, actual);
    }
}
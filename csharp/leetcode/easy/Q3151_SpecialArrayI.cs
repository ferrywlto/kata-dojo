public class Q3151_SpecialArrayI
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public bool IsArraySpecial(int[] nums)
    {
        if (nums.Length == 1) return true;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] % 2 == nums[i + 1] % 2) return false;
        }
        return true;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1], true},
        {[2,1,4], true},
        {[4,3,1,6], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = IsArraySpecial(input);
        Assert.Equal(expected, actual);
    }
}

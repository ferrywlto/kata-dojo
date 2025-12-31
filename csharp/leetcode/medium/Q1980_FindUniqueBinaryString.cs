public class Q1980_FindUniqueBinaryString
{
    // TC: O(n), n scale with length of nums, worst case while loop run nums.Length times
    // SC: O(n), set need to store all unique
    public string FindDifferentBinaryString(string[] nums)
    {
        if (nums.Length == 1) return nums[0] == "0" ? "1" : "0";

        var init = 0;
        var set = new HashSet<string>();
        foreach (var s in nums) set.Add(s);

        var result = init.ToString("b").PadLeft(nums.Length, '0');

        while (set.Contains(result))
        {
            init++;
            result = init.ToString("b").PadLeft(nums.Length, '0');
        }
        return result;
    }
    public static TheoryData<string[], string> TestData => new()
    {
        {["01","10"], "11"},
        {["10","11"], "00"},
        {["0","01"], "11"},
        {["111","011","001"], "101"},
        {["1"], "0"},
        {["0"], "1"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string expected)
    {
        var actual = FindDifferentBinaryString(input);
        Assert.Equal(actual.Length, input.Length);
        Assert.False(input.Contains(actual));
        Assert.False(input.Contains(expected));
    }
}

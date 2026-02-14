public class Q2206_DivideArrayIntoRqualPairs
{
    // TC: O(1), always operate 501 times
    // SC: O(1), same as time
    public bool DivideArray(int[] nums)
    {
        if (nums.Length % 2 != 0) return false;
        var count = new int[501];
        for (var i = 0; i < nums.Length; i++)
        {
            count[nums[i]]++;
        }
        for (var j = 0; j < count.Length; j++)
        {
            if (count[j] % 2 != 0) return false;
        }
        return true;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {3,2,3,2,2,2}, true],
        [new int[] {1,2,3,4}, false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = DivideArray(input);
        Assert.Equal(expected, actual);
    }
}

public class Q2206_DivideArrayIntoRqualPairs
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public bool DivideArray(int[] nums)
    {
        if (nums.Length % 2 != 0) return false;

        var list = nums
            .GroupBy(x => x)
            .Select(g => g.Count())
            .ToList();

        foreach (var count in list)
        {
            if (count % 2 != 0) return false;
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
public class Q2529_MaxCountOfPositiveIntegerAndNegativeInteger
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MaximumCount(int[] nums)
    {
        var posCount = 0;
        var negCount = 0;
        foreach (var n in nums)
        {
            if (n < 0) negCount++;
            else if (n > 0) posCount++;
        }
        return Math.Max(posCount, negCount);
    }
    public static List<object[]> TestData =>
    [
        [new int[] {-2,-1,-1,1,2,3}, 3],
        [new int[] {-3,-2,-1,0,0,1,2}, 3],
        [new int[] {5,20,66,1314}, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumCount(input);
        Assert.Equal(expected, actual);
    }
}

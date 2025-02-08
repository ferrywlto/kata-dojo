public class Q3158_FindXORofNumbersWhichAppearTwice
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int DuplicateNumbersXOR(int[] nums)
    {
        var set = new HashSet<int>();
        var result = 0;
        foreach (var n in nums)
        {
            if (!set.Add(n)) result ^= n;
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
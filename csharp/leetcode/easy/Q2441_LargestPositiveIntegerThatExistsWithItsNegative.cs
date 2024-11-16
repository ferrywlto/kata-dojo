public class Q2441_LargestPositiveIntegerThatExistsWithItsNegative
{
    public int FindMaxK(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {-1,2,-3,3}, 3],
        [new int[] {-1,10,6,7,-7,1}, 7],
        [new int[] {-10,8,6,7,-2,-3}, -1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindMaxK(input);
        Assert.Equal(expected, actual);
    }
}
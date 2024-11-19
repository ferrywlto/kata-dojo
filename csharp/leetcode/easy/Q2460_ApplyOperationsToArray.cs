public class Q2460_ApplyOperationsToArray
{
    public int[] ApplyOperations(int[] nums)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,2,1,1,0}, new int[] {1,4,2,0,0,0}],
        [new int[] {0,1}, new int[] {1,0}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = ApplyOperations(input);
        Assert.Equal(expected, actual);
    }
}
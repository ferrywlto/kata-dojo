public class Q3766_MinOpsToMakeBinaryPalindrome
{
    public int[] MinOperations(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[1,2,4], [0,1,1]},
        {[6,7,12], [1,0,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

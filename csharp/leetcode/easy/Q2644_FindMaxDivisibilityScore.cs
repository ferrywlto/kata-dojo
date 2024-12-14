public class Q2644_FindMaxDivisibilityScore
{
    public int MaxDivScore(int[] nums, int[] divisors)
    {
        return 0;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {

        {new int[] {2,9,15,50}, new int[] {5,3,7,2}, 2},
        {new int[] {4,7,9,3,9}, new int[] {5,2,3}, 3},
        {new int[] {20,14,21,10}, new int[] {10,16,20}, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = MaxDivScore(input1, input2);
        Assert.Equal(expected, actual);
    }
}
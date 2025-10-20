public class Q3684_MaxSumOfAtMostKDistinctElements
{
    public int[] MaxKDistinct(int[] nums, int k)
    {
        return [];
    }
    public static TheoryData<int[], int, int[]> TestData =>
        new()
        {
            { [84,93,100,77,90], 3, [100,93,90] },
            { [84,93,100,77,93], 3, [100,93,84] },
            { [1,1,1,2,2,2], 3, [2,1] },
        };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int k, int[] expected)
    {
        var result = MaxKDistinct(nums, k);
        Assert.Equal(expected, result);
    }
}

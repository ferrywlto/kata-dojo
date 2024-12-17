
public class Q2656_MaxSumWithExactlyKElements
{
    public int MaximizeSum(int[] nums, int k)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {new int[] {1,2,3,4,5}, 3, 18},
        {new int[] {5,5,5}, 2, 11},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MaximizeSum(input, k);
        Assert.Equal(expected, actual);
    }
}

public class Q2717_SemiOrderedPermutation
{
    public int SemiOrderedPermutation(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,1,4,3], 2},
        {[2,4,1,3], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SemiOrderedPermutation(input);
        Assert.Equal(expected, actual);
    }
}
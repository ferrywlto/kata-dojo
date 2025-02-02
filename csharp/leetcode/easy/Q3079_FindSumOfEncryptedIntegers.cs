public class Q3079_FindSumOfEncryptedIntegers
{
    public int SumOfEncryptedInt(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3], 6},
        {[10,21,31], 66},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SumOfEncryptedInt(input);
        Assert.Equal(expected, actual);
    }
}
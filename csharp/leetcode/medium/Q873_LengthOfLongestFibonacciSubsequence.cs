public class Q873_LengthOfLongestFibonacciSubsequence
{
    public int LenLongestFibSubseq(int[] arr)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4,5,6,7,8], 5},
        {[1,3,7,11,12,14,18], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = LenLongestFibSubseq(input);
        Assert.Equal(expected, actual);
    }
}
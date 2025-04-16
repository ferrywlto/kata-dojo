public class Q3512_MinOpsMakeArraySumDivisivbleByK
{
    public int MinOperations(int[] nums, int k) 
    {
        return 0;    
    }
    public static TheoryData<int[], int, int> TestData = new () 
    {
        {[3,9,7], 5, 4},
        {[4,1,3], 4, 0},
        {[3,2], 6, 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}
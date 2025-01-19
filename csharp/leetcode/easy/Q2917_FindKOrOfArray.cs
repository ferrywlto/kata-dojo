public class Q2917_FindKOrOfArray
{
    public int FindKOr(int[] nums, int k) {
     return 0;   
    }    
    public static TheoryData<int[], int, int> TestData => new ()
    {
        {[7,12,9,8,9,15], 4, 9},
        {[2,12,1,11,4,5], 6, 0},
        {[10,8,5,9,11,6,8], 1, 15},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = FindKOr(input, k);
        Assert.Equal(expected, actual);
    }
}
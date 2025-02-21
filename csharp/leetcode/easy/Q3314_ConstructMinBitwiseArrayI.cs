public class Q3314_ConstructMinBitwiseArrayI
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        // 0011
        // 0001
        // 0010
        // y = x | (x + 1)
        // 1001
        // 1000
        
        // 13
        // 1101
        // 1100 12
        // 1101 13

        // 31
        // 11111
        // 01111
        // 10000
        // 11110 30
        // 11111 
        var result = new List<int>();
        for(var i=0; i<nums.Count; i++)
        {
            // if()    
        }
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[2,3,5,7], [-1,1,4,3]},
        {[211,13,31], [9,12,15]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinBitwiseArray(input);
        Assert.Equal(expected, actual);
    }
}
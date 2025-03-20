public class Q3191_MinOpsToMakeBinaryArrayElementsEqualToOneI
{
    public int MinOperations(int[] nums) {
        return 0;
    }    
    public static TheoryData<int[], int> TestData => new ()
    {
        {[0,1,1,1,0,0], 3},
        {[0,1,1,1], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}
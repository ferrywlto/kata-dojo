public class Q3467_TransformArrayByParity
{
    public int[] TransformArray(int[] nums) {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new ()
    {
        {[4,3,2,1], [0,0,1,1]},
        {[1,5,1,4,2], [0,0,1,1,1]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = TransformArray(input);
        Assert.Equal(expected, actual);
    }
}
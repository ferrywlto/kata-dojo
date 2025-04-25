public class Q2657_FindPrefixCommanArrayOfTwoArrays
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        return [];
    }
    public static TheoryData<int[], int[], int[]> TestData => new()
    {
        {[1,3,2,4], [3,1,2,4], [0,2,3,4]},
        {[2,3,1], [3,1,2], [0,1,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int[] expected)
    {
        var actual = FindThePrefixCommonArray(input1, input2);
        Assert.Equal(expected, actual);
    }
}
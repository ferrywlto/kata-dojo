public class Q2161_PartitionArrayAccordingToGivenPivot
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        return [];
    }
    public static TheoryData<int[], int, int[]> TestData => new()
    {
        {[9,12,5,10,14,3,10], 10, [9,5,3,10,10,12,14]},
        {[-3,4,3,2], 2, [-3,2,4,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int input2, int[] expected)
    {
        var actual = PivotArray(input1, input2);
        Assert.Equal(expected, actual);
    }
}
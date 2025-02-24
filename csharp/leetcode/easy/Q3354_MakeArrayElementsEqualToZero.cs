public class Q3354_MakeArrayElementsEqualToZero
{
    public int CountValidSelections(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,0,2,0,3], 2},
        {[2,3,4,0,4,1,0], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountValidSelections(input);
        Assert.Equal(expected, actual);
    }
}
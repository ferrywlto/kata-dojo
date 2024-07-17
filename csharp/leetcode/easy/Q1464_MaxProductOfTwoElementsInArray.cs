
class Q1464_MaxProductOfTwoElementsInArray
{
    public int MaxProduct(int[] nums) 
    {
        return 0;
    }
}
class Q1464_MaxProductOfTwoElementsInArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {3,4,5,2}, 12],
        [new int[] {1,5,4,5}, 16],
        [new int[] {3,7}, 12],
    ];
}
public class Q1464_MaxProductOfTwoElementsInArrayTests
{
    [Theory]
    [ClassData(typeof(Q1464_MaxProductOfTwoElementsInArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1464_MaxProductOfTwoElementsInArray();
        var actual = sut.MaxProduct(input);
        Assert.Equal(expected, actual);
    }
}
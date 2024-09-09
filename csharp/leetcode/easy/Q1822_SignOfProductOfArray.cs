class Q1822_SignOfProductOfArray
{
    public int ArraySign(int[] nums)
    {
        return 0;
    }
}
class Q1822_SignOfProductOfArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {-1,-2,-3,-4,3,2,1}, 1],
        [new int[] {1,5,0,2,-3}, 0],
        [new int[] {-1,1,-1,1,-1}, -1],
    ];
}
public class Q1822_SignOfProductOfArrayTests
{
    [Theory]
    [ClassData(typeof(Q1822_SignOfProductOfArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1822_SignOfProductOfArray();
        var actual = sut.ArraySign(input);
        Assert.Equal(expected, actual);
    }
}
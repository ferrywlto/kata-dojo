class Q1929_ConcatenationOfArray
{
    public int[] GetConcatenation(int[] nums)
    {
        return [];
    }
}
class Q1929_ConcatenationOfArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,1}, new int[] {1,2,1,1,2,1}],
        [new int[]{1,3,2,1}, new int[] {1,3,2,1,1,3,2,1}],
    ];
}
public class Q1929_ConcatenationOfArrayTests
{
    [Theory]
    [ClassData(typeof(Q1929_ConcatenationOfArrayTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1929_ConcatenationOfArray();
        var actual = sut.GetConcatenation(input);
        Assert.Equal(expected, actual);
    }
}